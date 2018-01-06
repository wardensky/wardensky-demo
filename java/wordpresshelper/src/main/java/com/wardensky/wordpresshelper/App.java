package com.wardensky.wordpresshelper;

public class App {
	static String title = "楠楠弹古筝";
	static String videoUrl = "http://7.happykeke.top/video_%E5%8F%A4%E7%AD%9D%E8%A7%86%E9%A2%91-1.mp4";

	public static void main(String[] args) {
		MyJfinalConfig config = new MyJfinalConfig();
		config.start();
		LocalWpPostsSrv.SRV.addVideo(title, videoUrl);
		RemoteWpPostsSrv.SRV.addVideo(title, videoUrl);
		System.out.println("完成");
	}
}
