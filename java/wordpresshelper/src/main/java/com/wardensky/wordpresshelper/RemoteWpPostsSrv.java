package com.wardensky.wordpresshelper;

import com.google.inject.Singleton;

@Singleton
public class RemoteWpPostsSrv extends AbstractWppostsSrv {
	 
	final String GUID_PREFIX = "http://www.happykeke.top/?p=";

	@Override
	public void changeDb() {
		this.DB_NAME = "remote";
	}

	@Override
	public void addVideo(String title, String videoUrl) {
		 this.addVideo(title, videoUrl, GUID_PREFIX);
	}
}
