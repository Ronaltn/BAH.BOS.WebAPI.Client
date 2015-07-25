using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// 来源于API调用引发的异常信息类，
    /// 该类用于反序列化来自服务端的异常信息，非常规的异常类。
    /// </summary>
    [JsonObject]
    public class APIException
    {
        #region 静态定义

        /// <summary>
        /// 服务端异常序列化后字符串头，该字段只读。
        /// </summary>
        public static readonly string JSONHeader = "response_error:";//end field

        /// <summary>
        /// 检查字符串是否代表服务端口的异常。
        /// </summary>
        /// <param name="json">序列化字符串。</param>
        /// <returns>返回是否。</returns>
        public static bool CheckStringIsAPIException(string json)
        {
            if (string.IsNullOrEmpty(json) || json.Length < JSONHeader.Length)
            {
                return false;
            }//end if

            var header = json.Substring(0, JSONHeader.Length);
            return string.Equals(JSONHeader, header, StringComparison.OrdinalIgnoreCase);
        }//end method

        /// <summary>
        /// 将传入的序列化字符串去除头部定义。
        /// </summary>
        /// <param name="json">序列化字符串。</param>
        /// <returns>返回去除后的序列化字符串。</returns>
        public static string CutJSONHeader(string json)
        {
            if (!CheckStringIsAPIException(json))
            {
                return string.Empty;
            }//end if

            return json.Substring(JSONHeader.Length, json.Length - JSONHeader.Length);
        }//end method

        #endregion

        #region 公共属性

        [JsonProperty("_httpCode")]
        public int HttpCode { get; internal set; }//end property

        [JsonProperty]
        public string ClassName { get; internal set; }//end property

        [JsonIgnore]
        public IDictionary Data { get; internal set; }//end property

        [JsonProperty]
        public string ExceptionMethod { get; internal set; }//end property

        [JsonProperty("HelpURL")]
        public string HelpLink { get; internal set; }//end property

        [JsonProperty]
        public int HResult { get; internal set; }//end property

        [JsonIgnore]
        public Exception InnerException { get; internal set; }//end property

        [JsonProperty]
        public APIExceptionWrapper InnerExWrapper { get; internal set; }//end property

        [JsonProperty]
        public string Message { get; internal set; }//end property

        [JsonProperty]
        public string RemoteStackIndex { get; internal set; }//end property

        [JsonProperty("RemoteStackTraceString")]
        public string RemoteStackTrace { get; internal set; }//end property

        [JsonProperty]
        public string Source { get; internal set; }//end property

        [JsonProperty("StackTraceString")]
        public string StackTrace { get; internal set; }//end property

        [JsonProperty]
        public string WatsonBuckets { get; internal set; }//end property

        #endregion

        #region 公共方法

        /// <summary>
        /// 将API异常实例信息对象转为一个异常实例。
        /// </summary>
        /// <returns>返回一个异常实例。</returns>
        public Exception ToException()
        {
            return new Exception(string.Format("APIException:{0}", this.Message));
        }//end method

        #endregion

    }//end class
}//end namespace
