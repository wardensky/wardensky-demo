package com.wardensky.demo.mqkill;

public class GlobalConfig {
	public static String MQ_URL = "failover://tcp://192.168.163.50:61616?jms.prefetchPolicy.queuePrefetch=1";

	public volatile static boolean IS_ALIVE = true;
}
