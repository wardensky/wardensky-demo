package com.wardensky.wordpresshelper.model;

import java.util.Date;
import java.util.List;

import com.jfinal.ext.plugin.tablebind.TableBind;
import com.jfinal.plugin.activerecord.Db;
import com.jfinal.plugin.activerecord.IBean;
import com.jfinal.plugin.activerecord.Model;

@TableBind(pkName = "ID", tableName = "wp_posts")
public class Wpposts extends Model<Wpposts> implements IBean {
	private final String TABLE_NAME = "wp_posts";
	private static final long serialVersionUID = 1L;
	public static final Wpposts DAO = new Wpposts();

	public void setId(int id) {
		set("ID", id);
	}

	public int getId() {
		return get("ID");
	}

	public void setPostAuthor(long p) {
		set("post_author", p);
	}

	public int getPostAuthor() {
		return get("post_author");
	}

	public void setPostDate(Date p) {
		set("post_date", p);
	}

	public Date getPostDate() {
		return get("post_date");
	}

	public void setPostDateGmt(Date p) {
		set("post_date_gmt", p);
	}

	public Date getPostDateGmt() {
		return get("post_date_gmt");
	}

	public void setPostContent(String p) {
		set("post_content", p);
	}

	public String getPostContent() {
		return get("post_content");
	}

	public void setPostTitle(String p) {
		set("post_title", p);
	}

	public String getPostTitle() {
		return get("post_title");
	}

	public void setPostExcerpt(String p) {
		set("post_excerpt", p);
	}

	public String setPostExcerpt() {
		return get("post_excerpt");
	}

	public void setPostStatus(String p) {
		set("post_status", p);
	}

	public String setPostStatus() {
		return get("post_status");
	}

	public void setCommentStatus(String p) {
		set("comment_status", p);
	}

	public String getCommentStatus() {
		return get("comment_status");
	}

	public void setPingStatus(String p) {
		set("ping_status", p);
	}

	public String getPingStatus() {
		return get("ping_status");
	}

	public void setPostPassword(String p) {
		set("post_password", p);
	}

	public String getPostPassword() {
		return get("post_password");
	}

	public void setPostName(String p) {
		set("post_name", p);
	}

	public String getPostName() {
		return get("post_name");
	}

	public void setToPing(String p) {
		set("to_ping", p);
	}

	public String getToPing() {
		return get("to_ping");
	}

	public void setPinged(String p) {
		set("pinged", p);
	}

	public String getPinged() {
		return get("pinged");
	}

	public void setPostModified(Date p) {
		set("post_modified", p);
	}

	public Date getPostModified() {
		return get("post_modified");
	}

	public void setPostModifiedGmt(Date p) {
		set("post_modified_gmt", p);
	}

	public Date getPostModifiedGmt() {
		return get("post_modified_gmt");
	}

	public void setContentFiltered(String p) {
		set("post_content_filtered", p);
	}

	public String getContentFiltered() {
		return get("post_content_filtered");
	}

	public void setPostParent(long p) {
		set("post_parent", p);
	}

	public long getPostParent() {
		return get("post_parent");
	}

	public void setGuid(String p) {
		set("guid", p);
	}

	public String getGuid() {
		return get("guid");
	}

	public void setMenuOrder(int p) {
		set("menu_order", p);
	}

	public int getMenuOrder() {
		return get("menu_order");
	}

	public void setPostType(String p) {
		set("post_type", p);
	}

	public String getPostType() {
		return get("post_type");
	}

	public void setPostMimeType(String p) {
		set("post_mime_type", p);
	}

	public String getPostMimeType() {
		return get("post_mime_type");
	}

	public void setCommentCount(long p) {
		set("comment_count", p);
	}

	public long getCommentCount() {
		return get("comment_count");
	}

	public List<Wpposts> findAll() {
		String sql = "select * from " + this.TABLE_NAME;
		return this.find(sql);
	}

	public int finaMaxId() {
		String sql = "select MAX(ID) from " + this.TABLE_NAME;
		return Db.queryInt(sql);
	}

	public void addVideo(String title, String videoUrl) {
		int max = this.finaMaxId();
		int max1 = max - 1;
		int new1 = max + 1;
		int new2 = max + 2;
		Wpposts p1 =this.findById(max);
		Wpposts p2 =	this.findById(max1);
		p1.setPostTitle(title);
		p1.setPostContent("<code>[videojs mp4=\"" + videoUrl + "\"]</code>");
		p1.setGuid("http://localhost/wordpress/?p=" + new1);
		p1.setId(new1);
		p1.save();
		
		p2.setPostTitle(title);
		p2.setPostContent("<code>[videojs mp4=\"" + videoUrl + "\"]</code>");
		p2.setGuid("http://localhost/wordpress/?p=" + new2);
		p2.setId(new2);
		p2.save();
	}
}
