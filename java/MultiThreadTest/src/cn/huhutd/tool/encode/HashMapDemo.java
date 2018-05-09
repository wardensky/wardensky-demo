package cn.huhutd.tool.encode;

import java.util.HashMap;

public class HashMapDemo {
	public static void main(String[] args) {
		HashMap<Integer, String> map = new HashMap<Integer, String>();
		HashMap<Integer, String> map1 = new HashMap<Integer, String>(2);
		
		map.put(1, "monday");
		map1.put(2, "tuesday");
		System.out.println(map.size());
		System.out.println(map1.size());
	}
}
