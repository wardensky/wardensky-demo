# feign的用法

feign是java的http客户端


>Why Feign and not X?

>Feign uses tools like Jersey and CXF to write java clients for ReST or SOAP services. Furthermore, Feign allows you to write your own code on top of http libraries such as Apache HC. Feign connects your code to http APIs with minimal overhead and code via customizable decoders and error handling, which can be written to any text-based http API.

>How does Feign work?

>Feign works by processing annotations into a templatized request. Arguments are applied to these templates in a straightforward fashion before output. Although Feign is limited to supporting text-based APIs, it dramatically simplifies system aspects such as replaying requests. Furthermore, Feign makes it easy to unit test your conversions knowing this.

翻译如下：

>为什么是Feign而不是其它

>Feign应用Jersey和CXF为Rest和SOA服务编写java客户端。进一步的，Feign允许你在类似Apache HC的http库之上写自己的代码。

>Feign如何工作

>Feign把注解变成模板请求。


这篇[Feign真正正确的使用方法](https://www.jianshu.com/p/3d597e9d2d67)，比较简单的说明了feign的用法，很直观。