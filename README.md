# MyWeb我的商城

一直以来都想单独做个项目，在网上也找了很久了，今天终于下定决心，做个商城吧，没准以后还能用的上。初步这样设计的：
1. 基于.net mvc 完成商城的后台管理端，包括登陆，录入商品等等。
2. 基于.net webapi 和vuejs 完成商城的用户端，包括登陆注册，浏览商品，购物车，下单支付，体验一次前后端分离的感觉。
3. 数据库就用微软家的sql server2008版吧，毕竟后台语言选了c#嘛,之后再考虑开源的mongdb。

## 2017/11/10
1. 关于web API发布问题：
    `用户 'IIS APPPOOL\MyWebAPI' 登录失败。
    说明: 执行当前 Web 请求期间，出现未经处理的异常。请检查堆栈跟踪信息，以了解有关该错误以及代码中导致错误的出处的详细信息。 
    异常详细信息: System.Data.SqlClient.SqlException: 用户 'IIS APPPOOL\MyWebAPI' 登录失败。
    源错误: 
    执行当前 Web 请求期间生成了未经处理的异常。可以使用下面的异常堆栈跟踪信息确定有关异常原因和发生位置的信息。`
[解决问题](http://blog.csdn.net/jurson99/article/details/43764617) 

2. config.EnableCors(new EnableCorsAttribute("*","*","*"));//跨域支持代码,包Microsoft.AspNet.WebApi.Cors  
3. GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();//返回JSON格式数据
