using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.BusinessServiceOperation.SessionService
{
    /// <summary>
    /// 心跳服务。
    /// </summary>
    public class Heartbeat : ExecuteServiceOperation
    {
        /// <summary>
        /// 定义调用心跳服务参数的构造方法。
        /// </summary>
        public Heartbeat()
        {
            this.SetAssemblyName("BAH.BOS.WebAPI.ServiceStub");
            this.SetClassNameWithoutNamespace("SessionService");
            this.SetMethodName("Heartbeat");
        }//end constructor

    }//end class
}//end namespace
