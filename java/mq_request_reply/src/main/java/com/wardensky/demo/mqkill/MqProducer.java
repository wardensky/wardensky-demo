package com.wardensky.demo.mqkill;

import javax.jms.DeliveryMode;
import javax.jms.JMSException;
import javax.jms.Session;
import javax.jms.TextMessage;

import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;

import com.google.inject.Guice;
import com.google.inject.Injector;
import com.google.inject.Singleton;


@Singleton
public class MqProducer extends AbstractBaseMq {

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

	}

	public void close() throws JMSException {
		producer.close();
		session.close();
		connection.close();
	}

	public void sendRequest(String msg) throws JMSException {
		TextMessage message = session.createTextMessage(msg);
		System.out.println("client send message " + message.toString());
		producer.send(message);
	}

	public static void main(String[] args) throws JMSException {
		Injector injector = Guice.createInjector();
		MqProducer producer = injector.getInstance(MqProducer.class);
		producer.start(producer.qName);
		for (int i = 0; i < 2000; i++) {
			producer.sendRequest("aaa");
		}
		producer.close();
	}
}
