package com.wardensky.demo.mqkill;

public class ConsumerMonitor implements Runnable {
	private MqConsumer consumer;

	public ConsumerMonitor(MqConsumer consumer) {
		this.consumer = consumer;
	}

	public void run() {
		while (true) {
			try {
				Thread.sleep(2000);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			if (!this.consumer.getWorkStatus()) {
				System.out.println(this.consumer.getName() + " I'm not working +++++");
			}
		}
	}
}
