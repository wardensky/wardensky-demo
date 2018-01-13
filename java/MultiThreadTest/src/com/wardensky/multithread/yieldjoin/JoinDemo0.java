package com.wardensky.multithread.yieldjoin;

public class JoinDemo0 {
	public static void main(String[] args) throws InterruptedException {
		Thread0_1 t1 = new Thread0_1("aaa");
		Thread0_1 t2 = new Thread0_1("bbb");
		t1.start();
		t1.join();
		t2.start();
		//System.out.println("main thread finish");
	}
}

class Thread1_1 extends Thread {
	String name;

	public Thread1_1(String name) {
		this.name = name;
	}

	@Override
	public void run() {

		for (int i = 1; i < 15; i++) {

			System.out.println("I'm " + this.name + ". I'm doing something " + i);
			// Thread.yield();
		}

	}
}

class Thread1_2 extends Thread {
	String name;

	public Thread1_2(String name) {
		this.name = name;
	}

	@Override
	public void run() {

		for (int i = 1; i < 15; i++) {

			System.out.println("I'm " + this.name + ". I'm doing something " + i);
			// Thread.yield();
		}

	}
}
