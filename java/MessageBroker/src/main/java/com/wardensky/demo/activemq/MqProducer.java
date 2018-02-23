package com.wardensky.demo.activemq;

import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.DeliveryMode;
import javax.jms.Destination;
import javax.jms.JMSException;
import javax.jms.MessageProducer;
import javax.jms.Session;
import javax.jms.TemporaryQueue;
import javax.jms.TextMessage;

import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.alibaba.fastjson.JSONObject;
import com.wardensky.demo.MessageBroker.GlobalConfig;

public class MqProducer {
	private ConnectionFactory connectionFactory = null;
	private Connection connection = null;
	private Session session = null;
	private Destination destination = null;
	private MessageProducer producer = null;
	private String qName = "RESPONSE_Q";
	private static final Logger logger = LoggerFactory.getLogger(MqProducer.class);

	public MqProducer(String qName) {
		connectionFactory = new ActiveMQConnectionFactory(ActiveMQConnection.DEFAULT_USER,
				ActiveMQConnection.DEFAULT_PASSWORD, GlobalConfig.MQ_URL);
		this.qName = qName;
		try {
			connection = connectionFactory.createConnection();
			connection.start();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void close() throws JMSException {
		try {
			if (null != this.producer) {
				this.producer.close();
				this.producer = null;
			}
			if (null != this.destination) {
				this.destination = null;
			}
			if (null != this.session) {
				this.session.close();
				this.session = null;
			}
			if (null != connection) {
				connection.close();
			}
		} catch (Throwable ignore) {
			logger.error("", ignore);
		}
	}

	public void sendMessage(Object object) throws Exception {
		this.sendMessage(JSONObject.toJSONString(object));
	}

	public void sendMessage(String messageId, boolean result, String message, String condition) throws Exception {
		JSONObject json = new JSONObject();
		json.put("result", result);
		json.put("msg", message);
		json.put("condition", condition);
		json.put("correlationId", messageId);
		this.sendMessage(json);
	}

	public void sendMessage(String text) throws JMSException {
		this.init();
		TextMessage message = session.createTextMessage(text);
		this.producer.send(message);
		session.commit();
	}

	private void init() throws JMSException {
		if (this.session == null) {
			this.session = connection.createSession(Boolean.TRUE, Session.AUTO_ACKNOWLEDGE);
		}
		if (this.destination == null) {
			this.destination = session.createQueue(qName);
		}
		if (this.producer == null) {
			this.producer = session.createProducer(destination);
			this.producer.setDeliveryMode(DeliveryMode.NON_PERSISTENT);
		}
	}

	public void sendRequest(String msg) throws JMSException {
		this.init();
		TemporaryQueue tempQ = session.createTemporaryQueue();
		this.session.createConsumer(tempQ);
		TextMessage message = session.createTextMessage(msg);
		message.setJMSReplyTo(tempQ);
		this.producer.send(message);
		this.session.commit();
	}
}
