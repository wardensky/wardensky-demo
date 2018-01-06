package com.wardensky.test;

import java.util.TimerTask;

public class TimerTaskClass extends TimerTask {
	int count = 0;
	String name = "";
	public TimerTaskClass(String name) {
		this.name = name;
	}
	@Override
	public void run() {
		System.out.println(this.name + count++);
	}

}