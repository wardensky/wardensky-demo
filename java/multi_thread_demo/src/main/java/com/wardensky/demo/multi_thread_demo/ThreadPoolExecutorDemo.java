package com.wardensky.demo.multi_thread_demo;

import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.TimeUnit;

public class ThreadPoolExecutorDemo {

	public static void main(String[] args) {
		int produceTaskMaxNumber = 100;
		int produceTaskSleepTime = 1000;
		ThreadPoolExecutor threadPool = new ThreadPoolExecutor(10, 500, 3, TimeUnit.SECONDS,
				new ArrayBlockingQueue<Runnable>(3), new ThreadPoolExecutor.DiscardOldestPolicy());
		for (int i = 1; i <= produceTaskMaxNumber; i++) {
			try {
				String task = "task@ " + i;
				System.out.println("create thread and add it the pool：" + task);
				threadPool.execute(new ThreadDemo(task));
				Thread.sleep(produceTaskSleepTime);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}
}
