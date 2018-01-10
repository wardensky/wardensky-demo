package com.wardensky.demo.guicetest;

import com.google.inject.Guice;
import com.google.inject.Injector;
import com.google.inject.Singleton;

@Singleton
public class App2 {

	public static void main(String[] args) {
		//这个代码必须有
		Injector injector = Guice.createInjector();
		HelloPrinter printer = injector.getInstance(HelloPrinter.class);
		printer.print();
	}
}
