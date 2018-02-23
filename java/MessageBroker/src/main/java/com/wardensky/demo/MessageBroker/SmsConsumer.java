package com.wardensky.demo.MessageBroker;

import javax.jms.JMSException;
import javax.jms.TextMessage;

import com.alibaba.fastjson.JSON;
import com.jfinal.kit.LogKit;
import com.wardensky.demo.MessageBroker.model.SmsModel;
import com.wardensky.demo.activemq.MqConsumer;

public class SmsConsumer extends MqConsumer {

	@Override
	public void handleTextMessage(TextMessage txtMessage) {
		try {
			String text = txtMessage.getText();
			LogKit.info("接收到mq文本消息 = " + text);
			SmsModel o = JSON.parseObject(text, SmsModel.class);
			if (null != o) {
				SmsBroker.INST.send(o.getMobile(), o.getContent());
			} else {
				LogKit.info("消息不合规");
			}

		} catch (JMSException e) {
			e.printStackTrace();
		}
	}

}
