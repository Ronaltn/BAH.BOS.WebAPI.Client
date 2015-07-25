using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BAH.BOS.WebAPI.Client.Asynchronous
{
    /// <summary>
    /// 基于Kingdee.BOS.WebApi.Client.ApiClient的HTTP异步任务。
    /// </summary>
    /// <typeparam name="T">返回结果的泛型定义。</typeparam>
    public class KdHttpTask<T>
    {
        #region 公共属性

        /// <summary>
        /// API请求对象。
        /// </summary>
        public KdAPIRequest KdRequest { get; internal set; }//end property

        /// <summary>
        /// API结果对象。
        /// </summary>
        public APIResponse<T> Result { get; private set; }//end property

        /// <summary>
        /// 调用成功的方法回调。
        /// </summary>
        public Action<APIResponse<T>> SuccessCallBack { get; internal set; }//end property

        /// <summary>
        /// 调用过程的委托方法。
        /// </summary>
        public ProgressChangedHandler ProgressCallBack { get; internal set; }//end property }

        /// <summary>
        /// 调用失败的方法回调。
        /// </summary>
        public Action<APIResponse<T>> FailCallBack { get; internal set; }//end property

        /// <summary>
        /// HTTP超时时间设置，以秒为单位。
        /// </summary>
        public int Timeout { get; internal set; }//end property

        /// <summary>
        /// HTTP异步请求进度汇报时间间隔，以秒为单位。
        /// </summary>
        public int ReportInterval { get; internal set; }//end property

        /// <summary>
        /// 异步调用是否正在执行。
        /// </summary>
        public bool IsRunning { get; private set; }//end property

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法，将API结果对象实例化。
        /// </summary>
        public KdHttpTask()
        {
            this.Result = new APIResponse<T>();
            this.Timeout = 0;
            this.ReportInterval = 5;
            this.IsRunning = false;
        }//end constructor

        #endregion

        #region 内部方法

        /// <summary>
        /// 开启ApiClient的异步调用。
        /// </summary>
        internal void BeginApiClientExecute()
        {
            this.KdRequest.ExecuteAsync<T>(ExecuteSuccess, ProgressCallBack, ExecuteFail, Timeout, ReportInterval);
            this.IsRunning = true;
        }//end method

        #endregion

        #region 私有方法

        /// <summary>
        /// ApiClient执行成功时的回调定义。
        /// </summary>
        /// <param name="result">序列化对象。</param>
        private void ExecuteSuccess(T result)
        {
            this.IsRunning = false;
            this.Result.Body = result;
            this.Result.StatusCode = HttpStatusCode.OK;

            if (this.SuccessCallBack != null)
            {
                this.SuccessCallBack(this.Result);
            }//end if

        }//end method

        /// <summary>
        /// ApiClient执行失败时的回调定义。
        /// </summary>
        /// <param name="ex">捕获到异常对象。</param>
        private void ExecuteFail(ServiceException ex)
        {
            this.IsRunning = false;
            this.Result.Error = ex;
            this.Result.StatusCode = (HttpStatusCode)ex.GetHttpCode();
            if (this.FailCallBack != null)
            {
                this.FailCallBack(this.Result);
            }//end if

        }//end method


        #endregion

    }//end class
}//end namespace
