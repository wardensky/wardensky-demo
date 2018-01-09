package com.wardensky.wordpresshelper;

import com.google.inject.Singleton;

@Singleton
public class LocalWpPostsSrv extends AbstractWppostsSrv {
	 
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
