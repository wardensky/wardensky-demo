package com.wardensky.demo.mqkill;

public class HookThread extends Thread {
	private MqConsumer consumer;

	public HookThread(MqConsumer consumer) {
		this.consumer = consumer;
	}

	@Override
	public void run() {
		System.out.println("clean some work.");
		GlobalConfig.IS_ALIVE = false;
		if (this.consumer != null) {
			try {
				this.consumer.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}
}