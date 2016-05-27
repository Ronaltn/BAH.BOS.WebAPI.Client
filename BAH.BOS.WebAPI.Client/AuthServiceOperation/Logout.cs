using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.AuthServiceOperation
{
    /// <summary>
    /// 执行注销操作。
    /// </summary>
    public class Logout : APIOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.AuthService.Logout";
            }
        }//end property

        /// <summary>
        /// 操作的请求参数。
        /// </summary>
        public override string RequestParameters
        {
            get
            {
                var parametersArray = new object[0];
                return JsonConvert.SerializeObject(parametersArray);
            }//end get
        }//end property

        #endregion

    }//end class
}//end namespace
