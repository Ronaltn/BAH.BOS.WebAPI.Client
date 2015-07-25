using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;

namespace BAH.BOS.WebAPI.Client.Asynchronous
{
    /// <summary>
    /// 基于unirest_net.http.Unirest的HTTP异步任务。
    /// </summary>
    /// <typeparam name="T">结果泛型定义。</typeparam>
    public class UnirestHttpTask<T>
    {
        #region 公共属性

        /// <summary>
        /// API请求对象。
        /// </summary>
        public UnirestAPIRequest UnirestRequest { get; internal set; }//end property

        /// <summary>
        /// 系统线程异步任务。
        /// </summary>
        public Task<HttpResponse<string>> ThreadingTask { get; internal set; }//end property

        /// <summary>
        /// API结果对象。
        /// </summary>
        public APIResponse<T> Result { get; private set; }//end property

        /// <summary>
        /// 调用成功的方法回调。
        /// </summary>
        public Action<APIResponse<T>> SuccessCallBack { get; internal set; }//end property

        /// <summary>
        /// 调用失败的方法回调。
        /// </summary>
        public Action<APIResponse<T>> FailCallBack { get; internal set; }//end property

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法，将API结果对象实例化。
        /// </summary>
        public UnirestHttpTask()
        {
            this.Result = new APIResponse<T>();
        }//end constructor

        #endregion

        #region 内部方法

        /// <summary>
        /// 开启Unirest的异步调用。
        /// </summary>
        internal void BeginUnirestPostAsJson()
        {
            this.ThreadingTask.Start();
            this.ThreadingTask.ContinueWith(EndUnirestPostAsJson);
        }//end method

        /// <summary>
        /// 结束Unirest异步调用并获取异步任务对象。
        /// </summary>
        /// <param name="task">异步任务对象。</param>
        internal void EndUnirestPostAsJson(Task<HttpResponse<string>> task)
        {
            #region TaskCanceled

            //如果异步任务被取消，则什么都不做。
            if (task.IsCanceled)
            {
                return;
            }//end if

            #endregion

            #region TaskCompleted

            //如果成功完成，则获取结果。
            if (task.IsCompleted)
            {
                this.Result.StatusCode = (HttpStatusCode)task.Result.Code;
                var json = task.Result.Body;

                try
                {
                    //判断返回的是否是一个异常数据包
                    //如果是的，反序列化之，并引发一个异常
                    //反之正常反序列化
                    if (APIException.CheckStringIsAPIException(json))
                    {
                        this.Result.APIError = JsonConvert.DeserializeObject<APIException>(APIException.CutJSONHeader(json));
                        this.Result.Error = this.Result.APIError.ToException();
                    }
                    else
                    {
                        if (typeof(T).Equals(typeof(string)))
                        {
                            this.Result.Body = (T)(object)json;
                        }
                        else
                        {
                            this.Result.Body = JsonConvert.DeserializeObject<T>(json);
                        }
                    }//end if else
                }//end try
                catch (Exception ex)
                {
                    this.Result.Error = ex;
                }//end catch

                //最终根据是否有异常来执行相应的回调方法。
                if (this.Result.Error == null)
                {
                    if (this.SuccessCallBack != null)
                    {
                        this.SuccessCallBack(this.Result);
                    }//end if
                }
                else
                {
                    if (this.FailCallBack != null)
                    {
                        this.FailCallBack(this.Result);
                    }//end if
                }//end if else

            }//end if

            #endregion

            #region TaskFaulted

            //如果发生异常，则捕获异常。
            if (task.IsFaulted)
            {
                this.Result.Error = task.Exception;
                this.Result.StatusCode = (HttpStatusCode)task.Result.Code;

                if (this.FailCallBack != null)
                {
                    this.FailCallBack(this.Result);
                }//end if
            }//end if

            #endregion

        }//end method

        #endregion

    }//end class
}//end namespace
