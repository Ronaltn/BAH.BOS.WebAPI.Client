【它到底有多好用？首先我们来看一段Kingdee.BOS.WebApi.Client的调用代码：】

ApiClient client = new ApiClient("http://k3cloudv5/K3Cloud/");//K3 Cloud地址，注意尾处必须加/
string serviceName = "Kingdee.BOS.WebApi.ServicesStub.AuthService.ValidateUser";
object[] loginInfo = new object[] {        
        "001c420d973a862711e4a5daacd70218",//帐套Id
        "demo",//用户名
        "888888",//密码
        CultureInfo.CurrentCulture.LCID};//语言id

return client.Execute<string>(serviceName, loginInfo);
 

【来看BAH.BOS.WebAPI.Client的调用代码：】

return APIClient.ValidateUser("http://k3cloudv5/K3Cloud")
                       .SetDBId("001c420d973a862711e4a5daacd70218")
                       .SetUserName("demo")
                       .SetPassword("888888")
                       .SetUserLCID(CultureInfo.CurrentCulture.LCID)
                       .ToAPIRequest<KdAPIRequest>().Execute<string>();
 


【还不够？再来一段Kingdee.BOS.WebApi.Client的调用代码：】

ApiClient client = new ApiClient("http://k3cloudv5/K3Cloud/");//K3 Cloud地址，注意尾处必须加/
string serviceName = "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.View";
object[] viewInfo = new object[]{
        "BAH_PUR_SimplePurBusiness",
        new { CreateOrgId = 0, Number = string.Empty,Id = "120642" }//参数必须按此格式，否则无法返回数据
};

return client.Execute<string>(serviceName, viewInfo);
 

【来看BAH.BOS.WebAPI.Client的调用代码：】

return APIClient.View(Program.URL)
                      .SetDynamicFormViewId("BD_Currency")
                      .SetCreateOrgId(1)
                      .SetNumber("PRE001")
                      .SetId("1")
                      .ToAPIRequest<KdAPIRequest>().Execute<string>();
 


如果，你的业务系统需要频繁调用WebAPI，那么BAH.BOS.WebAPI.Client可能会是你最好的选择。