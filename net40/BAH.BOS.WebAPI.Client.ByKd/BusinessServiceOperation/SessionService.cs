using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.BusinessServiceOperation
{
    /// <summary>
    /// 会话服务。
    /// </summary>
    public class SessionService : ExecuteServiceOperation
    {
        /// <summary>
        /// 会话服务的参数构造方法。
        /// </summary>
        public SessionService()
        {
            this.SetAssemblyName("BAH.BOS.WebAPI.ServiceStub");
            this.SetClassNameWithoutNamespace("SessionService");
        }//end constructor

        /// <summary>
        /// 指定心跳方法参数。
        /// </summary>
        public virtual SessionService Heartbeat()
        {
            this.SetMethodName("Heartbeat");
            return this;
        }//end method

    }//end class
}//end namespace
