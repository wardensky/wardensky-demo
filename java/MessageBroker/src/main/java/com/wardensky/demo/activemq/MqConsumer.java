package com.wardensky.demo.activemq;

import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.Destination;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageConsumer;
import javax.jms.MessageListener;
import javax.jms.Session;
import javax.jms.TextMessage;

import org.apache.activemq.ActiveMQConnectionFactory;

import com.wardensky.demo.MessageBroker.GlobalConfig;
 

public abstract class MqConsumer implements MessageListener {

	public void run(String qName) throws JMSException {
		ConnectionFactory connectionFactory = new ActiveMQConnectionFactory(GlobalConfig.MQ_URL);
		Connection conn = connectionFactory.createConnection();
		conn.start();
		Session session = conn.createSession(false, Session.AUTO_ACKNOWLEDGE);
		Destination dest = session.createQueue(qName);
		MessageConsumer consumer = session.createConsumer(dest);
		consumer.setMessageListener(this);
	}

	@Override
	public void onMessage(Message message) {
		if (message instanceof TextMessage) {
			this.handleTextMessage((TextMessage) message);
		}
	}

	public abstract void handleTextMessage(TextMessage txtMessage);

}
