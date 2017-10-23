package com.wardensky.demo.multi_thread_demo;

/**
 * Hello world!
 *
 */
public class App {
	public static void main(String[] args) {
		ThreadDemo t1 = new ThreadDemo("");
		Thread th = new Thread(t1);

		th.start();
	}
}
