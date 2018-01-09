package com.wardensky.demo.mqkill;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.Session;
import javax.jms.TextMessage;

import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;

import com.google.inject.Guice;
import com.google.inject.Injector;

public class MqConsumer extends AbstractBaseMq implements MessageListener {
	private String name;

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	private boolean workStatus;

	public synchronized boolean getWorkStatus() {
		return workStatus;
	}

	public synchronized void setWorkStatus(boolean status) {
		this.workStatus = status;
	}

	public void start(String qName) throws JMSException {
		this.qName = qName;
		connectionFactory = new ActiveMQConnectionFactory(ActiveMQConnection.DEFAULT_USER,
				ActiveMQConnection.DEFAULT_PASSWORD, GlobalConfig.MQ_URL);
		connection = connectionFactory.createConnection();
		connection.start();
		session = connection.createSession(Boolean.FALSE, Session.AUTO_ACKNOWLEDGE);
		destination = session.createQueue(qName);
		this.consumer = session.createConsumer(destination);
		this.consumer.setMessageListener(this);
	}

	public void onMessage(Message message) {
		this.setWorkStatus(true);
		System.out.println(this.destination.toString());
		TextMessage textMessage = (TextMessage) message;
		try {
			System.out.println(this.name + "server receive message " + textMessage.getText());
		} catch (JMSException e1) {
			e1.printStackTrace();
		}

		try {
			for (int i = 0; i < 10; i++) {
				Thread.sleep(1000);
				System.out.println(this.name + " I'm working>>>>" + i);
			}
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		this.setWorkStatus(false);
	}

	/**
	 * @throws JMSException
	 *             没搞明白怎么停止监听
	 */
	public void close() throws JMSException {
		System.out.println(this.name + " I'm closed.");
	//	this.consumer.setMessageListener(null);
		consumer.close();
		session.close();
		connection.close();
	}

	public static void main(String[] args) throws JMSException, InterruptedException {

		Injector injector = Guice.createInjector();

		ExecutorService executorService = Executors.newCachedThreadPool();
		for (int i = 0; i < 100; i++) {
			MqConsumer consumer1 = injector.getInstance(MqConsumer.class);
			consumer1.setName("name=" + i);
			executorService.execute(new ConsumerThread(consumer1));
		}
		

		// Thread.sleep(300);
		// MqConsumer consumer2 = injector.getInstance(MqConsumer.class);
		// consumer2.setName("orange");
		// consumer2.start(consumer2.qName);
		// Thread thread2 = new Thread(new ConsumerMonitor(consumer2));
		// thread2.start();
		// Runtime.getRuntime().addShutdownHook(new HookThread(consumer2));
	}

}
