package com.wardensky.wordpresshelper;

import com.google.inject.Inject;

public class App {
	static String title = "【视频】可可在海边玩";
	static String videoUrl = "http://7xq6cg.com1.z0.glb.clouddn.com/video_%E5%8F%AF%E5%8F%AF%E5%9C%A8%E6%B5%B7%E8%BE%B9-compress.mp4";
	@Inject
	static LocalWpPostsSrv localSrv;

	@Inject
	static RemoteWpPostsSrv remoteSrv;
	
	public static void main(String[] args) {

		MyJfinalConfig config = new MyJfinalConfig();
		config.start();
		localSrv.addVideo(title, videoUrl);
		remoteSrv.addVideo(title, videoUrl);
		System.out.println("完成");
	}
}
