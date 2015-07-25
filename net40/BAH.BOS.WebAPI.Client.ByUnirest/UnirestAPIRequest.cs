using BAH.BOS.WebAPI.Client.Asynchronous;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;
using unirest_net.request;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// 基于unirest_net.http.Unirest对象的API请求对象。
    /// </summary>
    public class UnirestAPIRequest : APIRequest
    {
        #region 公共方法

        /// <summary>
        /// 以同步的形式发起HTTP请求并返回类型为泛型的API响应对象。
        /// </summary>
        /// <typeparam name="T">定义结果的泛型。</typeparam>
        /// <returns>返回结果类型为泛型的API响应对象。</returns>
        public virtual APIResponse<T> ToAPIResponse<T>()
        { 
            var result = new APIResponse<T>();

            try
            {
                var response = Post().asString();
                result.StatusCode = (HttpStatusCode)response.Code;
                var json = response.Body;

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
        /// 以异步的形式发起HTTP请求并返回类型为泛型的API响应对象。
        /// </summary>
        /// <typeparam name="T">定义结果的泛型。</typeparam>
        /// <param name="successCallback">调用成功的方法回调。</param>
        /// <param name="failCallback">调用失败的方法回调。</param>
        /// <returns>返回HTTP异步任务。</returns>
        public virtual UnirestHttpTask<T> ToAPIResponseAsync<T>(
            Action<APIResponse<T>> successCallback = null,
            Action<APIResponse<T>> failCallback = null
            )
        {
            var task = new UnirestHttpTask<T>();
            task.UnirestRequest = this;
            task.ThreadingTask = this.Post().asStringAsync();
            task.SuccessCallBack = successCallback;
            task.FailCallBack = failCallback;
            task.BeginUnirestPostAsJson();
            return task;
        }//end method

        /// <summary>
        /// 以HTTP POST方法发起请求。
        /// </summary>
        /// <returns>返回发起HttpWebRequest对象。</returns>
        public virtual HttpRequest Post()
        {
            return Unirest.post(this.URL)
                          .headers(this.Headers)
                          .body(this.Body);
        }//end method

        #endregion

    }//end class
}//end namespace
