package com.wardensky.demo.guicetest;

import com.google.inject.Guice;
import com.google.inject.Inject;
import com.google.inject.Injector;
import com.google.inject.Singleton;

@Singleton
public class App {
	@Inject
	private HelloPrinter printer;

	public void hello() {
		printer.print();
	}

	public static void main(String[] args) {
		Injector injector = Guice.createInjector();
		App sample = injector.getInstance(App.class);
		sample.hello();
	}
}

@Singleton
class HelloPrinter {

	public void print() {
		System.out.println("Hello, World");
	}

}
