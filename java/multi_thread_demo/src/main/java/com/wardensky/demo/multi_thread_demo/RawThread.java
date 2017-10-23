package com.wardensky.demo.multi_thread_demo;


public class RawThread {
	public void run() {
		ThreadDemo t1 = new ThreadDemo("task");

		Thread thread1 = new Thread(t1);
		thread1.start();

}
}
