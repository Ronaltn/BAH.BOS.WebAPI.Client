using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using BAH.BOS.WebAPI.Client.Asynchronous;
using BAH.BOS.WebAPI.Client.DynamicFormOperation;
using Newtonsoft.Json;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// 基于System.Net.HttpWebRequest对象的API请求对象。
    /// </summary>
    public class ClientAPIRequest : APIRequest
    {
        #region 公共属性

        /// <summary>
        /// HTTP访问组件。
        /// </summary>
        public ClientHttpUtility HttpUtility { get; protected internal set; }//end property

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法。
        /// </summary>
        public ClientAPIRequest()
        {
            this.HttpUtility = new ClientHttpUtility(this);
        }//end constructor

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置HTTP请求中内容类型。
        /// </summary>
        /// <param name="contentType">内容类型。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ClientAPIRequest SetContentType(string contentType)
        {
            if (this.Headers == null) return this;

            if (this.Headers.ContainsKey("Content-Type"))
            {
                this.Headers["Content-Type"] = contentType;
            }
            else
            {
                this.Headers.Add("Content-Type", contentType);
            }

            return this;
        }//end method

        /// <summary>
        /// 以POST方法发起请求并接收结果类型为泛型的API响应对象。
        /// </summary>
        /// <typeparam name="T">定义结果的泛型。</typeparam>
        /// <returns>返回结果类型为泛型的API响应对象。</returns>
        public virtual APIResponse<T> ToAPIResponse<T>()
        {
            var result = new APIResponse<T>();

            try
            {
                var request = this.HttpUtility.CreateHttpWebRequest();
                this.HttpUtility.WriteHttpWebRequestStream(request.GetRequestStream());
                var response = this.HttpUtility.CreateHttpWebResponse(request);
                result.StatusCode = response.StatusCode;
                var json = this.HttpUtility.GetResponseString(response);

                if (APIException.CheckStringIsAPIException(json))
                {
                    result.APIError = JsonConvert.DeserializeObject<APIException>(APIException.CutJSONHeader(json));
                    throw result.APIError.ToException();
                }//end if

                //判断返回的是否是一个异常数据包
                //如果是的，反序列化之，并引发一个异常
                //反之正常反序列化
                if (APIException.CheckStringIsAPIException(json))
                {
                    result.APIError = JsonConvert.DeserializeObject<APIException>(APIException.CutJSONHeader(json));
                    throw result.APIError.ToException();//这里会引发异常
                }//end if

                if (typeof(T).Equals(typeof(string)))
                {
                    result.Body = (T)(object)json;
                }
                else
                {
                    result.Body = JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }//end method

        /// <summary>
        /// 以POST方法发起异步请求并接收结果类型为泛型的API响应对象。
        /// </summary>
        /// <typeparam name="T">定义结果的泛型。</typeparam>
        /// <param name="successCallBack">调用成功的方法回调。</param>
        /// <param name="failCallBack">调用失败的方法回调。</param>
        /// <returns>返回HTTP异步任务。</returns>
        public virtual ClientHttpTask<T> ToAPIResponseAsync<T>(
            Action<APIResponse<T>> successCallBack,
            Action<APIResponse<T>> failCallBack)
        {
            var task = new ClientHttpTask<T>();
            task.SuccessCallBack = successCallBack;
            task.FailCallBack = failCallBack;
            task.ClientRequest = this;
            task.HttpRequest = this.HttpUtility.CreateHttpWebRequest();
            task.HttpRequest.BeginGetRequestStream(new AsyncCallback(task.RunRequestTask), null);
            return task;
        }//end method

        #endregion

    }//end class
}//end namespace
