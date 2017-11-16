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
EnableCorsAttribute的构造函数指定的三个参数均为*，表示支持所有的访问。第一个参数表示访问的源；第二个参数表示访问的头信息；第三个参数表示允许的方法，比如：HEAD、OPTIONS、DELETE、GET、POST等等。 
3. GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();//返回JSON格式数据
4. git提交的时候报错：fatal: TaskCanceledException encountered.身份验证输入用户名和密码就ok

## 2017/11/13
1. 关于拦截器Filter
mvc 的filter继承System.Web.Mvc.ActionFilterAttribute
添加全局过滤器：FilterConfig文件filters.Add(new YourFilter());
webapi 的filter继承System.Web.Http.Filters.ActionFilterAttribute
添加全局过滤器：WebApiConfig文件config.Filters.Add(new YourFilter());
2. 关于控制器Controller
因为有两个网站用户端和管理端，用户端继承ApiController，管理端继承Controller，所以在Controller文件夹下建立两个目录，分别存放两种Controller

## 2017/11/14
1. vuejs的axios网络传输和vuex的状态管理简单使用
2. 登陆跳转首页

## 2017/11/15
1. 解决问题：`无法删除数据库 "MyWeb"，因为该数据库当前正在使用`
        use master    
        go   
             
        declare @dbname sysname    
        set @dbname = 'MyWeb' --这个是要删除的数据库库名    
             
        declare @s nvarchar(1000)    
        declare tb cursor local   
        for  
            select s = 'kill   ' + cast(spid as varchar)  
            from   master.dbo.sysprocesses  
            where  dbid = DB_ID(@dbname)    
             
        open   tb      
        fetch   next   from   tb   into   @s    
        while @@fetch_status = 0  
        begin  
            exec (@s)   
            fetch next from tb into @s  
        end    
        close   tb    
        deallocate   tb        
        exec ('drop   database   [' + @dbname + ']')
这个原理类似于操作系统里面通过pid干掉程序了