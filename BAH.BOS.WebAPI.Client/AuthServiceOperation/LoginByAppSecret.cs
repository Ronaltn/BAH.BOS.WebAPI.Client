using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.AuthServiceOperation
{
    /// <summary>
    /// 执行按应用密钥登录操作。
    /// </summary>
    public class LoginByAppSecret : APIOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.AuthService.LoginByAppSecret";
            }
        }//end property

        /// <summary>
        /// 操作的请求参数。
        /// </summary>
        public override string RequestParameters
        {
            get
            {
                var parametersArray = new object[]{
                    this.DBId,
                    this.UserName,
                    this.AppId,
                    this.AppSecret,
                    this.UserLCID == default(int) ? CultureInfo.CurrentCulture.LCID : this.UserLCID
                };

                return JsonConvert.SerializeObject(parametersArray);
            }//end get
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写数据库标识属性值。
        /// </summary>
        public virtual string DBId { get; set; }//end property

        /// <summary>
        /// 读写用户名属性值。
        /// </summary>
        public virtual string UserName { get; set; }//end property

        /// <summary>
        /// 读写应用主键属性值。
        /// </summary>
        public virtual string AppId { get; set; }//end property

        /// <summary>
        /// 读写应用密钥属性值。
        /// </summary>
        public virtual string AppSecret { get; set; }//end property

        /// <summary>
        /// 读写用户本地化语言标识属性值。
        /// </summary>
        public virtual int UserLCID { get; set; }//end property

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置数据库标识。
        /// </summary>
        /// <param name="dbId">数据库标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual LoginByAppSecret SetDBId(string dbId)
        {
            this.DBId = dbId;
            return this;
        }//end method

        /// <summary>
        /// 设置用户名。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual LoginByAppSecret SetUserName(string userName)
        {
            this.UserName = userName;
            return this;
        }//end method

        /// <summary>
        /// 设置应用主键。
        /// </summary>
        /// <param name="appId">应用主键。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual LoginByAppSecret SetAppId(string appId)
        {
            this.AppId = appId;
            return this;
        }//end method

        /// <summary>
        /// 设置应用密钥。
        /// </summary>
        /// <param name="appSecret">应用密钥。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual LoginByAppSecret SetAppSecret(string appSecret)
        {
            this.AppSecret = appSecret;
            return this;
        }//end method

        /// <summary>
        /// 设置用户本地化语言标识。
        /// </summary>
        /// <param name="lcId">用户本地化语言标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual LoginByAppSecret SetUserLCID(int lcId)
        {
            this.UserLCID = lcId;
            return this;
        }//end method

        /// <summary>
        /// 设置用户本地化语言标识。
        /// </summary>
        /// <param name="culture">区域信息对象。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual LoginByAppSecret SetUserLCID(CultureInfo culture)
        {
            this.UserLCID = culture.LCID;
            return this;
        }//end method

        #endregion

    }//end class
}//end namespace
