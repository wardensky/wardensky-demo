package com.wardensky.demo.MessageBroker;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

import com.jfinal.kit.LogKit;

public class SmsBroker {
	private SmsBroker() {
	}

	public final static SmsBroker INST = new SmsBroker();

	private String apikey = "8812e5efc12279f33f2f72c1d0291780";
	private String url = "http://m.5c.com.cn/api/send/index.php?";
	private String username = "srtc";
	private String password = "deef3155530";

	public boolean send(String mobile, String content) {
		StringBuffer sb = new StringBuffer(url);
		sb.append("apikey=" + this.apikey);
		sb.append("&username=" + this.username);
		sb.append("&password=" + this.password);
		sb.append("&mobile=" + mobile);
		String inputline = "";
		try {
			sb.append("&content=" + URLEncoder.encode(content, "GBK"));
			URL url = new URL(sb.toString());
			HttpURLConnection connection = (HttpURLConnection) url.openConnection();
			connection.setRequestMethod("POST");
			BufferedReader in = new BufferedReader(new InputStreamReader(url.openStream()));
			inputline = in.readLine();
		} catch (IOException e) {
			LogKit.error("", e);
		}
		boolean ret = inputline.startsWith("success");
		if (ret) {
			LogKit.info("发送短信成功:mobile=" + mobile + "  \tcontent=" + content);
		} else {
			LogKit.info("发送短信失败:mobile=" + mobile + "  \tcontent=" + content);
		}
		return ret;
	}
}
