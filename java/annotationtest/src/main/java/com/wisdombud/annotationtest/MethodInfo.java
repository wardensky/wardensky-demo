package com.wisdombud.annotationtest;

import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;

@Retention(RetentionPolicy.RUNTIME)
public @interface MethodInfo {
	String author() default "Pankaj";

	String date();

	int revision() default 1;

	String comments();

}
