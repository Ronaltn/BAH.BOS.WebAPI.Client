using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// API响应结果。
    /// </summary>
    /// <typeparam name="T">结果泛型定义。</typeparam>
    public class APIResponse<T>
    {
        /// <summary>
        /// HTTP状态码。
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }//end proeprty

        /// <summary>
        /// 异常实例。
        /// </summary>
        public Exception Error { get; set; }//end property

        /// <summary>
        /// API异常信息。
        /// </summary>
        public APIException APIError { get; set; }//end property

        /// <summary>
        /// 泛型结果对象。
        /// </summary>
        public T Body { get; set; }//end property
    }//end class
}//end namespace