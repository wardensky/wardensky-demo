package com.wisdombud.droolsdemo;

public class Message {
	public static final int HELLO = 0;
	public static final int BYE = 1;

	private String msg;
	private int status;

	public String getMsg() {
		return msg;
	}

	public void setMsg(String msg) {
		this.msg = msg;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}
}
