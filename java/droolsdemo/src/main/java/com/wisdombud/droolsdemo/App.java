package com.wisdombud.droolsdemo;

import org.drools.KnowledgeBase;
import org.drools.KnowledgeBaseFactory;
import org.drools.builder.KnowledgeBuilder;
import org.drools.builder.KnowledgeBuilderError;
import org.drools.builder.KnowledgeBuilderErrors;
import org.drools.builder.KnowledgeBuilderFactory;
import org.drools.builder.ResourceType;
import org.drools.io.ResourceFactory;
import org.drools.runtime.StatefulKnowledgeSession;

/**
 * Hello world!
 *
 */
public class App {
	private static StatefulKnowledgeSession readKnowledgeSession(String name) throws Exception {
		KnowledgeBuilder kbuilder = KnowledgeBuilderFactory.newKnowledgeBuilder();
		kbuilder.add(ResourceFactory.newClassPathResource(name), ResourceType.DRL);
		KnowledgeBuilderErrors errors = kbuilder.getErrors();
		System.out.println(errors.toString());
		KnowledgeBase kbase = KnowledgeBaseFactory.newKnowledgeBase();
		kbase.addKnowledgePackages(kbuilder.getKnowledgePackages());
		return kbase.newStatefulKnowledgeSession();
	}

	public static void main(String[] args) {
		try {
			StatefulKnowledgeSession session = readKnowledgeSession("Sample.drl");
			Message msg = new Message();
			msg.setMsg("zhaokeke");
			msg.setStatus(Message.HELLO);
			session.insert(msg);
			session.fireAllRules();
			System.out.println(msg.getStatus());
			System.out.println(msg.getMsg());
		} catch (Exception ex) {
			System.out.println("exception:" + ex.getMessage());
		}
	}
 
}
