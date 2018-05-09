package com.zch.jexltest;

import org.apache.commons.jexl3.JexlBuilder;
import org.apache.commons.jexl3.JexlContext;
import org.apache.commons.jexl3.JexlEngine;
import org.apache.commons.jexl3.JexlExpression;
import org.apache.commons.jexl3.MapContext;

public class App {
	public static void main(String[] args) {
		foo1();
	}

	public static void foo1() {
		String expression = "current gt limit";
		JexlEngine jexl = new JexlBuilder().create();
		JexlContext jc = new MapContext();
		JexlExpression create = jexl.createExpression(expression);
		jc.set("current", 10);
		jc.set("limit", 11);
		Object o = create.evaluate(jc);
		System.out.println(o);
	}
}
