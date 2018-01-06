package com.wardensky.wordpresshelper;

import java.util.Date;
import java.util.List;

import com.jfinal.plugin.activerecord.Db;
import com.wardensky.wordpresshelper.model.Wpposts;

public abstract class AbstractWppostsSrv {

	public abstract void changeDb();

	String DB_NAME = "local";

	public List<Wpposts> findAll() {
		this.changeDb();
		String sql = "select * from " + Wpposts.TABLE_NAME;
		return Wpposts.DAO.use(this.DB_NAME).find(sql);
	}

	public int finaMaxId() {
		this.changeDb();
		String sql = "select MAX(ID) from " + Wpposts.TABLE_NAME;
		return Db.use(this.DB_NAME).queryInt(sql);
	}

	public void addVideo(String title, String videoUrl) {
		
	}

	public void addVideo(String title, String videoUrl, String guidPrefix) {
		this.changeDb();
		int max = this.finaMaxId();

		int newId = max + 1;

		Wpposts p1 = new Wpposts();

		p1.setPostTitle(title);
		p1.setPostContent("<code>[videojs mp4=\"" + videoUrl + "\"]</code>");
		p1.setGuid(guidPrefix + newId);
		p1.setId(newId);
		p1.setPostAuthor(1);
		p1.setPostStatus("publish");
		p1.setCommentStatus("open");
		p1.setPingStatus("open");
		p1.setPostParent(0);
		p1.setMenuOrder(0);
		p1.setPostType("post");
		p1.setCommentCount(0);
		p1.setPostDate(new Date());
		p1.setPostDateGmt(new Date());
		p1.setPostModified(new Date());
		p1.setPostModifiedGmt(new Date());
		p1.setPostExcerpt("");
		p1.setToPing("");
		p1.setPinged("");
		p1.setPostContentFiltered("");
		p1.use(this.DB_NAME).save();

	}
}
