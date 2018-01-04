package com.wardensky.wordpresshelper;

import com.wardensky.wordpresshelper.model.Wpposts;

public class App {
	public static void main(String[] args) {
		HhtdJfinalConfig config = new HhtdJfinalConfig();
		config.start();
	 
		Wpposts.DAO.addVideo("可可和爷爷在商场玩气球","http://7.happykeke.top/video_可可和爷爷在商场.mp4");
	}
}
