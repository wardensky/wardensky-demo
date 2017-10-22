package com.wardensky.demo.mq_request_reply;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class MqClientUtil {
	private static final Logger logger = LoggerFactory.getLogger(MqClientUtil.class);
	public static final int TIME_OUT = 600000;// 10 minute
	public static String sendRequest(String qName, String paraJson) {
		MqClient client = new MqClient();
		String ret = "";
		try {
			client.start(qName);
			client.sendRequest(paraJson);
			int count = 0;
			while (true) {
				count++;
				if (count > TIME_OUT / 10) {
					logger.error("request time out");
					ret = "";
					break;
				}
				if (client.response == null) {
					Thread.sleep(10);
				} else {
					ret = client.response;
					break;
				}
			}
			client.close();
		} catch (Exception e) {
			logger.error("", e);
		}
		return ret;
	}
}
