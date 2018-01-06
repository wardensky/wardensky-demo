package com.wardensky.wordpresshelper;

public class LocalWpPostsSrv extends AbstractWppostsSrv {
	public static final LocalWpPostsSrv SRV = new LocalWpPostsSrv();
	final String GUID_PREFIX = "http://localhost/wordpress/?p=";
	@Override
	public void changeDb() {
		this.DB_NAME = "local";
	}
	
	@Override
	public void addVideo(String title, String videoUrl) {
		 this.addVideo(title, videoUrl, GUID_PREFIX);
	}
}
