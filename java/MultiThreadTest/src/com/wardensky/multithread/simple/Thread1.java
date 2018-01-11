package com.wardensky.multithread.simple;

public class Thread1 extends Thread{

	@Override
	public void run() {
		System.out.println("this thread will die.");
	}
}
