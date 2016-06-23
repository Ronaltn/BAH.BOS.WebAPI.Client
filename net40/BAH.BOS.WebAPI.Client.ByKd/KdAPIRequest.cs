using BAH.BOS.WebAPI.Client.Asynchronous;
using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// 基于Kingdee.BOS.WebApi.Client.ApiClient对象的API请求对象。
    /// </summary>
    public class KdAPIRequest : APIRequest
    {
        #region 私有域

        private static string _rootUrl;
        private static ApiClient _client;

        #endregion

        #region 公共方法

        /// <summary>
        /// 以同步的形式发起HTTP请求并返回类型为泛型的API响应对象。
        /// </summary>
        /// <typeparam name="T">定义结果的泛型。</typeparam>
        /// <param name="failCallback">调用失败的方法回调。</param>
        /// <param name="timeout">HTTP超时时间，以秒为单位。</param>
        /// <returns>返回结果类型为泛型的API响应对象。</returns>
        public virtual APIResponse<T> ToAPIResponse<T>(FailCallbackHandler failCallback = null, int timeout = 100)
        {
            var result = new APIResponse<T>();

            try
            {
                result.Body = Execute<T>(failCallback, timeout);
            }//end try
            catch(APIException ex)
            {
                result.StatusCode = (HttpStatusCode)ex.GetHttpCode();
                result.Error = ex;
                result.APIError = ex;
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            result.StatusCode = HttpStatusCode.OK;
            return result;
        }//end method

        /// <summary>
        /// 以异步的形式发起HTTP请求并返回类型为泛型的API响应对象。
        /// </summary>
        /// <typeparam name="T">定义结果的泛型。</typeparam>
        /// <param name="successCallback">调用成功的方法回调。</param>
        /// <param name="progressCallback">调用过程中进度变化的方法回调。</param>
        /// <param name="failCallback">调用失败的方法回调。</param>
        /// <param name="timeout">HTTP超时时间，以秒为单位。</param>
        /// <param name="reportInterval">HTTP异步执行中反馈进度的时间间隔，以秒为单位。</param>
        /// <returns>返回HTTP异步任务。</returns>
        public virtual KdHttpTask<T> ToAPIResponseAsync<T>(
            Action<APIResponse<T>> successCallback = null,
            ProgressChangedHandler progressCallback = null,
            Action<APIResponse<T>> failCallback = null,
            int timeout = 0,
            int reportInterval = 5)
        { 
            var task = new KdHttpTask<T>();
            task.KdRequest = this;
            task.SuccessCallBack = successCallback;
            task.ProgressCallBack = progressCallback;
            task.FailCallBack = failCallback;
            task.BeginApiClientExecute();
            return task;

        }//end method

        /// <summary>
        /// 以同步的形式发起HTTP请求并返回执行结果，
        /// 结果以泛型反序列化获得。
        /// </summary>
        /// <typeparam name="T">泛型对象。</typeparam>
        /// <param name="failCallback">执行失败的方法委托。</param>
        /// <param name="timeout">超时时间，默认100秒。</param>
        /// <returns>返回反序列化的泛型结果。</returns>
        public virtual T Execute<T>(FailCallbackHandler failCallback = null, int timeout = 100)
        {
            this.CreateApiClientInstance();

            var paramatersArray = JsonConvert.DeserializeObject<object[]>(this.Operation.RequestParameters);
            return _client.Execute<T>(this.Operation.ServiceName, paramatersArray, failCallback, timeout);
        }//end method

        /// <summary>
        /// 以异步的形式发起HTTP请求并返回执行结果。
        /// </summary>
        /// <typeparam name="T">泛型对象。</typeparam>
        /// <param name="successCallback">执行成功的方法委托。</param>
        /// <param name="progressCallback">执行中的方法委托。</param>
        /// <param name="failCallback">执行失败的方法委托。</param>
        /// <param name="timeout">超时时间，默认0秒。</param>
        /// <param name="reportInterval">执行汇报进程间隔，默认5秒。</param>
        /// <returns>返回ApiRequest对象。</returns>
        public virtual ApiRequest ExecuteAsync<T>(
            Action<T> successCallback = null,
            ProgressChangedHandler progressCallback = null, 
            FailCallbackHandler failCallback = null, 
            int timeout = 0, 
            int reportInterval = 5)
        {
            this.CreateApiClientInstance();

            var paramatersArray = JsonConvert.DeserializeObject<object[]>(this.Operation.RequestParameters);
            return _client.ExecuteAsync<T>(this.Operation.ServiceName, 
                successCallback, 
                paramatersArray, 
                progressCallback, 
                failCallback, 
                timeout, 
                reportInterval);
        }//end method

        #endregion

        #region 私有方法

        /// <summary>
        /// 创建ApiClient对象实例。
        /// </summary>
        protected virtual void CreateApiClientInstance()
        {
            var rootUrl = this.Operation.RootUrl;
            if (rootUrl.LastIndexOf("/", 0, 1) < 0)
            {
                rootUrl = string.Format("{0}/", rootUrl);
            }//end if

            if (string.Equals(rootUrl, _rootUrl, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }//end if

            _rootUrl = rootUrl;
            _client = new ApiClient(rootUrl);
        }//end method

        #endregion

    }//end class
}//end namespace
