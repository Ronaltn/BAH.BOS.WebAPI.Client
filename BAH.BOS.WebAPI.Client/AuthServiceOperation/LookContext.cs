using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.AuthServiceOperation
{
    /// <summary>
    /// 执行获取用户上下文对象操作。
    /// </summary>
    public class LookContext : APIOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.AuthService.ValidateUserToken";
            }
        }//end property

        /// <summary>
        /// 操作的请求参数。
        /// </summary>
        public override string RequestParameters
        {
            get
            {
                var parametersArray = new object[] 
                {
                    this.UserToken
                };
                return JsonConvert.SerializeObject(parametersArray);
            }//end get
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写用户标记属性值。
        /// </summary>
        public virtual string UserToken { get; set; }//end property

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置数据库标识。
        /// </summary>
        /// <param name="dbId">数据库标识。</param>
        /// <param name="userToken">用户令牌。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual GetContext SetUserToken(string userToken)
        {
            this.UserToken = userToken;
            return this;
        }//end method

        #endregion

    }//end class
}//end namespace
