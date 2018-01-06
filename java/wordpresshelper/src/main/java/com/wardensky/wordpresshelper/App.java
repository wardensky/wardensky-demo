package com.wardensky.wordpresshelper;

public class App {
	static String title = "【视频】可可在海边玩";
	static String videoUrl = "http://7xq6cg.com1.z0.glb.clouddn.com/video_%E5%8F%AF%E5%8F%AF%E5%9C%A8%E6%B5%B7%E8%BE%B9-compress.mp4";

	public static void main(String[] args) {
		MyJfinalConfig config = new MyJfinalConfig();
		config.start();
		LocalWpPostsSrv.SRV.addVideo(title, videoUrl);
		RemoteWpPostsSrv.SRV.addVideo(title, videoUrl);
		System.out.println("完成");
	}
}
