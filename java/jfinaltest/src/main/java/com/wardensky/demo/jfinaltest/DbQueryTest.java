package com.wardensky.demo.jfinaltest;

import java.util.List;

import com.jfinal.plugin.activerecord.Db;
import com.jfinal.plugin.activerecord.Record;

public class DbQueryTest extends MyJfinalConfig {
	public static void main(String[] args) {
		MyJfinalConfig config = new DbQueryTest();
		config.start();

	}

	/**
	 * 正确写法
	 */
	static void testDb0() {
		String sql = "select wechat_openid from base_wechat_user ;";
		List<String> data = Db.query(sql);
		String r = data.get(0);
		System.out.println(r.toString());
	}

	/**
	 * 错误写法
	 */
	static void testDb1() {
		String sql = "select wechat_openid from base_wechat_user ;";
		List<Record> data = Db.query(sql);
		Record r = data.get(0);
		System.out.println(r.toString());
	}

	/**
	 * 错误写法
	 */
	static void testDb2() {
		String sql = "select id, wechat_openid from base_wechat_user ;";
		List<Record> data = Db.query(sql);
		Record r = data.get(0);
		System.out.println(r.toString());
	}

	/**
	 * 错误写法
	 */
	static void testDb3() {
		String sql = "select * from base_wechat_user ;";
		List<Record> data = Db.query(sql);
		Record r = data.get(0);
		System.out.println(r.toString());
	}

	/**
	 * 正确写法
	 */
	static void testDb4() {
		String sql = "select * from base_wechat_user ;";
		List<Record> data = Db.find(sql);
		Record r = data.get(0);
		System.out.println(r.toString());
	}

	/**
	 * 正确写法
	 */
	static void testDb5() {
		String sql = "select wechat_openid from base_wechat_user ;";
		List<Record> data = Db.find(sql);
		Record r = data.get(0);
		System.out.println(r.toString());
	}
}
