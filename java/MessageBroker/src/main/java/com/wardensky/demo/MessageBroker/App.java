package com.wardensky.demo.MessageBroker;

import javax.jms.JMSException;

public class App {
	public static void main(String[] args) throws JMSException {
		SmsConsumer consumer = new SmsConsumer();
		consumer.run(GlobalConfig.MQ_SMS);
	}
}
