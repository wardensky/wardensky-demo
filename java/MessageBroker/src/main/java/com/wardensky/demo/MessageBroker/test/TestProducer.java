package com.wardensky.demo.MessageBroker.test;

import com.wardensky.demo.MessageBroker.GlobalConfig;
import com.wardensky.demo.MessageBroker.model.SmsModel;
import com.wardensky.demo.activemq.MqProducer;

public class TestProducer {
	public static void main(String[] args) throws Exception {
		MqProducer producer = new MqProducer(GlobalConfig.MQ_SMS);
		SmsModel model = new SmsModel();
		model.setContent("你好啊");
		model.setMobile("15811276774");
		producer.sendMessage(model);
		producer.close();
	}
}
