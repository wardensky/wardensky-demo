package com.wardensky.demo.mqkill;

import javax.jms.JMSException;

public class ConsumerThread implements Runnable {
	private MqConsumer consumer;

	public ConsumerThread(MqConsumer consumer) {
		this.consumer = consumer;
	}

	public void run() {

		try {
			this.consumer.start(this.consumer.qName);
		} catch (JMSException e) {
			e.printStackTrace();
		}
		Thread thread1 = new Thread(new ConsumerMonitor(this.consumer));
		thread1.start();
		Runtime.getRuntime().addShutdownHook(new HookThread(this.consumer));
	}
}
