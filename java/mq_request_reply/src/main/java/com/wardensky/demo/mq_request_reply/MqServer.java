package com.wardensky.demo.mq_request_reply;

import java.util.HashMap;
import java.util.Map;

import javax.jms.DeliveryMode;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.Session;
import javax.jms.TextMessage;

import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import net.sf.json.JSONObject;

public abstract class MqServer extends MqAbstractBase implements MessageListener {
	private static final Logger logger = LoggerFactory.getLogger(MqServer.class);
	protected String urlStr = "";
	protected String referer = "";
	protected String cookie = "";
	protected Map<String, String> params = new HashMap<String, String>();

	public String getStringFromJson(JSONObject paraJson, String name) {
		String ret = "";
		if (paraJson.containsKey(name)) {
			ret = paraJson.getString(name);
		}
		return ret;
	}

	public JSONObject getJsonFromString(String json) {
		return JSONObject.fromObject(json);
	}

	public void start() throws JMSException, Exception {
		if (this.qName == null) {
			throw new Exception("qname is null");
		}
		connectionFactory = new ActiveMQConnectionFactory(ActiveMQConnection.DEFAULT_USER,
				ActiveMQConnection.DEFAULT_PASSWORD, GlobalConfig.MQ_URL);
		connection = connectionFactory.createConnection();
		connection.start();
		session = connection.createSession(Boolean.FALSE, Session.AUTO_ACKNOWLEDGE);
		destination = session.createQueue(qName);
		producer = session.createProducer(null);
		producer.setDeliveryMode(DeliveryMode.NON_PERSISTENT);
		this.consumer = session.createConsumer(destination);
		this.consumer.setMessageListener(this);
	}

	public void onMessage(Message message) {
		try {
			logger.info("server receive message ");
			TextMessage textMessage = (TextMessage) message;
			TextMessage replyMessage = this.session.createTextMessage();
			replyMessage.setText(this.handleMsg(textMessage.getText()));
			replyMessage.setJMSCorrelationID(textMessage.getJMSCorrelationID());
			producer.send(textMessage.getJMSReplyTo(), replyMessage);
			logger.info("server send reply message");
			logger.info("q = " + textMessage.getJMSReplyTo().toString());
		} catch (JMSException e) {
			e.printStackTrace();
		}
	}

	public abstract String handleMsg(String json);

	public void close() throws JMSException {
		producer.close();
		consumer.close();
		session.close();
		connection.close();
	}

}
