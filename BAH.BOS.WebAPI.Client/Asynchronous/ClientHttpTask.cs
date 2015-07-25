using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace BAH.BOS.WebAPI.Client.Asynchronous
{
    /// <summary>
    /// HTTP异步任务。
    /// </summary>
    /// <typeparam name="T">返回结果的泛型定义。</typeparam>
    public class ClientHttpTask<T>
    {
        #region 公共属性
        
        /// <summary>
        /// API请求对象。
        /// </summary>
        public ClientAPIRequest ClientRequest { get; protected internal set; }//end property

        /// <summary>
        /// HTTP请求对象。
        /// </summary>
        public HttpWebRequest HttpRequest { get; protected internal set; }//end property

        /// <summary>
        /// HTTP响应对象。
        /// </summary>
        public HttpWebResponse HttpResponse { get; private set; }//end property

        /// <summary>
        /// API结果对象。
        /// </summary>
        public APIResponse<T> Result { get; private set; }//end property

        /// <summary>
        /// 调用成功的方法回调。
        /// </summary>
        public Action<APIResponse<T>> SuccessCallBack { get; protected internal set; }//end property

        /// <summary>
        /// 调用失败的方法回调。
        /// </summary>
        public Action<APIResponse<T>> FailCallBack { get; protected internal set; }//end property

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法，将API结果对象实例化。
        /// </summary>
        public ClientHttpTask()
        {
            this.Result = new APIResponse<T>();
        }//end constructor

        #endregion

        #region 受保护内部方法

        /// <summary>
        /// 运行请求任务。
        /// </summary>
        /// <param name="ar">异步结果对象。</param>
        protected internal void RunRequestTask(IAsyncResult ar)
        {
            try
            {
                //获取HTTP异步请求流对象
                using (var stream = this.HttpRequest.EndGetRequestStream(ar))
                {
                    this.ClientRequest.HttpUtility.WriteHttpWebRequestStream(stream);
                }//end using
            }
            catch (Exception ex)
            {
                this.Result.Error = ex;
            }

            if (this.Result.Error != null)
            {
                if (this.FailCallBack != null) this.FailCallBack(this.Result);
            }
            else
            {
                //开始HTTP异步响应
                this.HttpRequest.BeginGetResponse(new AsyncCallback(this.RunResponseTask), null);
            }
        }//end method

        /// <summary>
        /// 运行响应任务。
        /// </summary>
        /// <param name="ar">异步结果对象。</param>
        protected internal void RunResponseTask(IAsyncResult ar)
        {
            try
            {
                //获取HTTP异步响应对象
                this.HttpResponse = (HttpWebResponse)this.HttpRequest.EndGetResponse(ar);
                this.Result.StatusCode = this.HttpResponse.StatusCode;

                //接收json字符串
                var json = this.ClientRequest.HttpUtility.GetResponseString(this.HttpResponse);

                //判断返回的是否是一个异常数据包
                //如果是的，反序列化之，并引发一个异常
                //反之正常反序列化
                if (APIException.CheckStringIsAPIException(json))
                {
                    this.Result.APIError = JsonConvert.DeserializeObject<APIException>(APIException.CutJSONHeader(json));
                    throw this.Result.APIError.ToException();
                }//end if

                if (typeof(T).Equals(typeof(string)))
                {
                    this.Result.Body = (T)(object)json;
                }
                else
                {
                    this.Result.Body = JsonConvert.DeserializeObject<T>(json);
                }
            }//end try
            catch (Exception ex)
            {
                this.Result.Error = ex;
            }

            if (this.Result.Error != null)
            {
                if (this.FailCallBack != null) this.FailCallBack(this.Result);
            }
            else
            {
                if (this.SuccessCallBack != null) this.SuccessCallBack(this.Result);
            }
        }//end method

        #endregion

    }//end class
}//end namespace
