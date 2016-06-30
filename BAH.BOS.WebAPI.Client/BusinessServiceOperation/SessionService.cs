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
            this.SetClassNameWithoutNamespace("Session.SessionService");
        }//end constructor

        /// <summary>
        /// 指定登录会话是否有效方法参数。
        /// </summary>
        /// <returns>返回实例本身。</returns>
        public virtual SessionService Alive()
        {
            this.SetMethodName("Alive");
            return this;
        }//end method

        /// <summary>
        /// 指定心跳方法参数。
        /// </summary>
        /// <remarks>返回实例本身。</remarks>
        public virtual SessionService Heartbeat()
        {
            this.SetMethodName("Heartbeat");
            return this;
        }//end method

    }//end class
}//end namespace
