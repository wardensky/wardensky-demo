package com.wardensky.demo.mq_request_reply;

import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.Destination;
import javax.jms.MessageConsumer;
import javax.jms.MessageProducer;
import javax.jms.Session;

public abstract class MqAbstractBase {
	protected ConnectionFactory connectionFactory = null;
	protected Connection connection = null;
	protected Session session = null;
	protected Destination destination = null;
	protected MessageProducer producer = null;
	protected MessageConsumer consumer = null;
	protected String qName = "adminQueue";
}
