package com.chzhao.mongo_test;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;

/**
 * Hello world!
 *
 */

@EnableAutoConfiguration
public class App implements CommandLineRunner {

    @Autowired
    private CustomerRepository repository;

    public static void main(String[] args) {
        SpringApplication.run(App.class, args);
    }

    public void run(String... args) throws Exception {

        for (int i = 0; i < 10000; i++) {
            repository.save(new Customer(i + "", "zhao"));
        }
        long cou = repository.countByLastName("zhao");
        System.out.println(cou);

        System.out.println("Customers found with findAll():");
        System.out.println("-------------------------------");
        for (Customer customer : repository.findAll()) {
            System.out.println(customer);
        }
        System.out.println();
        repository.deleteByFirstName("zhao");

        // fetch an individual customer
        System.out.println("Customer found with findByFirstName('Alice'):");
        System.out.println("--------------------------------");
        System.out.println(repository.findByFirstName("Alice"));

        System.out.println("Customers found with findByLastName('Smith'):");
        System.out.println("--------------------------------");
        for (Customer customer : repository.findByLastName("zhao")) {
            System.out.println(customer);
        }

    }

}
