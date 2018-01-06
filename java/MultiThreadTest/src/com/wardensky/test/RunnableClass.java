package com.wardensky.test;

import java.util.ArrayList;
import java.util.List;

public class RunnableClass implements Runnable {
	int count = 0;
	String name = "";

	public RunnableClass(String name) {
		this.name = name;
	}

	@Override
	public void run() {
		System.out.println(name + count++);
		List<String> arrayList = new ArrayList<String>();
	}

}