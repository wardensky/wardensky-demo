package com.wardensky.demo.mq_request_reply;

import java.util.UUID;

import javax.jms.DeliveryMode;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.Session;
import javax.jms.TemporaryQueue;
import javax.jms.TextMessage;

import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class MqClient extends MqAbstractBase implements MessageListener {

	private TemporaryQueue tempQ;
	private static final Logger logger = LoggerFactory.getLogger(MqClient.class);
	public String response = null;

	public void start(String qName) throws JMSException {
		this.qName = qName;
		connectionFactory = new ActiveMQConnectionFactory(ActiveMQConnection.DEFAULT_USER,
				ActiveMQConnection.DEFAULT_PASSWORD, GlobalConfig.MQ_URL);
		connection = connectionFactory.createConnection();
		connection.start();
		session = connection.createSession(Boolean.FALSE, Session.AUTO_ACKNOWLEDGE);
		destination = session.createQueue(this.qName);
		producer = session.createProducer(destination);
		producer.setDeliveryMode(DeliveryMode.NON_PERSISTENT);
		tempQ = session.createTemporaryQueue();
		this.consumer = session.createConsumer(tempQ);
		this.consumer.setMessageListener(this);
	}

	public void close() throws JMSException {
		producer.close();
		consumer.close();
		session.close();
		connection.close();
	}

	public static void main(String[] args) {
		MqClient client = new MqClient();
		try {
			String qName = "adminQueue";
			client.start(qName);
			for (int i = 0; i < 10; i++) {
				client.sendRequest("message " + i);
				Thread.sleep(1000 * 2);
			}
			Thread.sleep(1000 * 300);
			client.close();
		} catch (Exception e) {
			logger.error("", e);
		}
	}

	public void sendRequest(String msg) throws JMSException {
		TextMessage message = session.createTextMessage(msg);
		message.setJMSReplyTo(tempQ);
		String correlationId = UUID.randomUUID().toString();
		message.setJMSCorrelationID(correlationId);
		logger.info("client send message " + message.getJMSCorrelationID());
		logger.info("tempq " + tempQ.getQueueName());
		producer.send(message);
	}

	public void onMessage(Message message) {
		TextMessage textMessage = (TextMessage) message;
		try {
			logger.info("client receive message");
			logger.info(textMessage.getText());
			this.response = textMessage.getText();
		} catch (Exception ex) {
			logger.error("", ex);
		}
	}
}
