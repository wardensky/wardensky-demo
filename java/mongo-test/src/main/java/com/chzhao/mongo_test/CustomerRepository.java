package com.chzhao.mongo_test;

import java.util.List;

import org.springframework.data.mongodb.repository.MongoRepository;

public interface CustomerRepository extends MongoRepository<Customer, String> {

    public Customer findByFirstName(String firstName);

    public List<Customer> findByLastName(String lastName);

    public long deleteByFirstName(String firstName);

    public long countByLastName(String lastName);
}