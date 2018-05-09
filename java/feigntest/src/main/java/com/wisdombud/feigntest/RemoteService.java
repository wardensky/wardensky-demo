package com.wisdombud.feigntest;

import feign.Param;
import feign.RequestLine;

public interface RemoteService {
	@RequestLine("GET /several-serial-number?count={count}")
	String getOwner(@Param(value = "count") String count);
}
