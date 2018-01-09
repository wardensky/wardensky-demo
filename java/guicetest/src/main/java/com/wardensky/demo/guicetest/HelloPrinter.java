package com.wardensky.demo.guicetest;

import com.google.inject.Singleton;

@Singleton
class HelloPrinter {

	public void print() {
		System.out.println("Hello, World");
	}

}