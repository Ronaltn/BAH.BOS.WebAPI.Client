using BAH.BOS.WebAPI.Client.AuthServiceOperation;
using BAH.BOS.WebAPI.Client.BusinessServiceOperation;
using BAH.BOS.WebAPI.Client.DynamicFormOperation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// API调用客户端。
    /// </summary>
    public class APIClient
    {
        #region 公共属性

        /// <summary>
        /// K/3 Cloud系统的根级URL，
        /// 例如：http://localhost/K3Cloud
        /// </summary>
        public virtual string URL { get; private set; }//end property

        #endregion

        #region 构造方法

        /// <summary>
        /// 构造方法，将K/3 Cloud系统的根级URL在实例化时传入。
        /// </summary>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        public APIClient(string url)
        {
            this.URL = url;
        }//end constructor

        #endregion

        #region 公共方法

        /// <summary>
        /// 根据传入的泛型定义实例化API操作对象。
        /// </summary>
        /// <typeparam name="T">泛型定义，必须继承APIOperation并且可无参实例化。</typeparam>
        /// <returns>返回泛型定义的API操作对象实例。</returns>
        public virtual T CreateAPIOperation<T>() where T : APIOperation, new()
        {
            return CreateAPIOperation<T>(this.URL);
        }//end method

        /// <summary>
        /// 根据传入的泛型定义实例化API操作对象。
        /// </summary>
        /// <typeparam name="T">泛型定义，必须继承APIOperation并且可无参实例化。</typeparam>
        /// <param name="url">K/3 Cloud系统的根级URL。</param>
        /// <returns>返回泛型定义的API操作对象实例。</returns>
        public static T CreateAPIOperation<T>(string url) where T : APIOperation, new()
        {
            return new T().SetRootUrl<T>(url);
        }//end method

        #endregion

    }//end class
}//end method
