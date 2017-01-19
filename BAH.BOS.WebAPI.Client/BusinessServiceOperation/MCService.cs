using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.BusinessServiceOperation
{
    /// <summary>
    /// 管理中心服务。
    /// </summary>
    public class MCService : ExecuteServiceOperation
    {
        /// <summary>
        /// 会话服务的参数构造方法。
        /// </summary>
        public MCService()
        {
            this.SetAssemblyName("BAH.BOS.WebAPI.ServiceStub");
            this.SetClassNameWithoutNamespace("MC.MCService");
        }//end constructor

        /// <summary>
        /// 获取业务数据库。
        /// </summary>
        /// <returns>返回实例本身。</returns>
        public virtual MCService GetDataCenterList()
        {
            this.SetMethodName("GetDataCenterList");
            return this;
        }//end method

    }//end class
}//end namespace
