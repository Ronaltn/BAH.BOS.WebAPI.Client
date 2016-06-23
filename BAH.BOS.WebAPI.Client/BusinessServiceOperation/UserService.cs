using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.BusinessServiceOperation
{
    /// <summary>
    /// 用户服务。
    /// </summary>
    public class UserService : ExecuteServiceOperation
    {
        /// <summary>
        /// 会话服务的参数构造方法。
        /// </summary>
        public UserService()
        {
            this.SetAssemblyName("BAH.BOS.WebAPI.ServiceStub");
            this.SetClassNameWithoutNamespace("User.UserService");
        }//end constructor

    }//end class
}//end namespace
