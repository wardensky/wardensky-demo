package com.wardensky.multithread.yieldjoin;

public class YieldDemo0 {
	public static void main(String[] args) {
		Thread0_1 t1 = new Thread0_1("aaa");
		Thread0_2 t2 = new Thread0_2("bbb");
		t1.setPriority(Thread.MIN_PRIORITY);
		t2.setPriority(Thread.MAX_PRIORITY);
		t1.start();
		t2.start();
	}
}

class Thread0_1 extends Thread {
	String name;

	public Thread0_1(String name) {
		this.name = name;
	}

	@Override
	public void run() {

		for (int i = 1; i < 15; i++) {

			System.out.println("I'm " + this.name + ". I'm doing something " + i);
		//	Thread.yield();
		}

	}
}

class Thread0_2 extends Thread {
	String name;

	public Thread0_2(String name) {
		this.name = name;
	}

	@Override
	public void run() {

		for (int i = 1; i < 15; i++) {

			System.out.println("I'm " + this.name + ". I'm doing something " + i);
		//	Thread.yield();
		}

	}
}
