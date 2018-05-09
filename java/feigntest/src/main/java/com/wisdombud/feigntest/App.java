package com.wisdombud.feigntest;

import java.util.Date;

import feign.Feign;
import feign.Request.Options;
import feign.Retryer;

/**
 * Hello world!
 *
 */
public class App {
	public static void main(String[] args) {
		System.out.println("Hello World!");
		long l1 = new Date().getTime();
		for (int i = 0; i < 1000; i++) {
			RemoteService service = Feign.builder().options(new Options(1000, 3500))
					.retryer(new Retryer.Default(5000, 5000, 3))
					.target(RemoteService.class, "http://192.168.163.113:8002");
			String result = service.getOwner("1");
		}
		System.out.println("finish " + ((new Date().getTime()) - l1));

	}
}
