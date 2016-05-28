using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// API操作抽象类，针对操作定义参数并发起API请求。
    /// </summary>
    public abstract class APIOperation
    {
        #region 公共属性

        /// <summary>
        /// K/3 Cloud系统的根级URL，
        /// 例如：http://localhost/K3Cloud
        /// </summary>
        public virtual string RootUrl { get; set; }//end property

        /// <summary>
        /// 操作的服务名称定义，在派生类中定义，
        /// 例如：Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.ExcuteOperation
        /// </summary>
        public abstract string ServiceName { get; }//end property

        /// <summary>
        /// 操作的URL定义，在尾处补充后缀，
        /// 例如：Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.ExcuteOperation.common.kdsvc
        /// </summary>
        public virtual string OperationUrl
        {
            get
            {
                return string.Format("{0}.common.kdsvc", this.ServiceName);
            }//end get
        }//end property

        /// <summary>
        /// 使用HTTP发起请求完整的URL。
        /// </summary>
        public virtual string RequestUrl
        {
            get
            {
                return Path.Combine(RootUrl, OperationUrl).Replace(@"\", @"/");
            }//end get
        }//end property

        /// <summary>
        /// 操作的请求参数，在派生类中定义，
        /// 此参数对应Body中的parameters
        /// </summary>
        public abstract string RequestParameters { get; }//end property

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法，什么都不做。
        /// </summary>
        public APIOperation()
        {
            //DO NOTHING
        }//end constructor

        /// <summary>
        /// 构造方法，将K/3 Cloud系统的根级URL在实例化时传入。
        /// </summary>
        /// <param name="rootUrl">K/3 Cloud系统的根级URL。</param>
        public APIOperation(string rootUrl)
        {
            this.RootUrl = rootUrl;
        }//end constructor

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置K/3 Cloud系统的根级URL。
        /// </summary>
        /// <typeparam name="T">继承APIOperation的类。</typeparam>
        /// <param name="rootUrl">K/3 Cloud系统的根级URL，例如：http://localhost/K3Cloud </param>
        /// <returns>返回T定义类型的实例对象。</returns>
        public virtual T SetRootUrl<T>(string rootUrl) where T : APIOperation
        {
            this.RootUrl = rootUrl;
            return this as T;
        }//end method

        /// <summary>
        /// 转向API请求。
        /// </summary>
        /// <returns>返回API请求实例对象。</returns>
        public virtual T ToAPIRequest<T>() where T : APIRequest, new()
        {
            return new T().SetOperation<T>(this);
        }//end method

        /// <summary>
        /// 转向API请求。
        /// </summary>
        /// <returns>返回API请求实例对象。</returns>
        public virtual APIRequest ToAPIRequest()
        {
            return this.ToAPIRequest<APIRequest>();
        }//end method

        #endregion

    }//end class
}//end namespace