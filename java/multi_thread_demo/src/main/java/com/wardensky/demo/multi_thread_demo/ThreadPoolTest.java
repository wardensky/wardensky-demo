package com.wardensky.demo.multi_thread_demo;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.Serializable;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

public class ThreadPoolTest implements Runnable, Serializable {

	private static final long serialVersionUID = 1L;

	public ThreadPoolTest(String task) {
		System.out.println(task);
	}

	public void run() {
		String urlStr = "http://192.168.163.66:8080/index!login";

		Map<String, String> params = new HashMap<String, String>();
		params.put("userName", "admin");
		params.put("password", "670b14728ad9902aecba32e22fa4f6bd");
		StringBuilder sbR = new StringBuilder();

		try {
			URL url = new URL(urlStr);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setRequestProperty("X-Requested-With", "XMLHttpRequest");

			conn.setDoInput(true);
			conn.setDoOutput(true);// 允许连接提交信息
			conn.setInstanceFollowRedirects(false);
			conn.setRequestMethod("POST");// 网页默认“GET”提交方式

			if (params != null) {
				StringBuffer sb = new StringBuffer();
				for (Entry<String, String> entry : params.entrySet()) {
					sb.append(entry.getKey() + "=" + entry.getValue() + "&");
				}
				conn.setRequestProperty("Content-Length", String.valueOf(sb.toString().length()));

				OutputStream os = conn.getOutputStream();
				os.write(sb.toString().getBytes());
				os.close();
			}

			BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream()));

			// 取返回的页面
			String line = br.readLine();
			while (line != null) {
				sbR.append(line);
				line = br.readLine();
			}

		} catch (IOException e) {
			System.out.println(e.getMessage());
		}

	}

}
