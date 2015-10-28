using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// 客户端自定义的HTTP访问组件。
    /// </summary>
    public class ClientHttpUtility
    {
        #region 私有域

        /// <summary>
        /// API请求对象，由外部传入。
        /// </summary>
        private APIRequest _request = null;

        /// <summary>
        /// Cookie信息容器。
        /// </summary>
        private static CookieContainer _cookieContainer = new CookieContainer();

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法，传入API请求对象。
        /// </summary>
        /// <param name="request">API请求对象。</param>
        public ClientHttpUtility(APIRequest request)
        {
            this._request = request;
        }//end constructor

        #endregion

        #region 公共方法

        /// <summary>
        /// 创建HTTP请求对象。
        /// </summary>
        /// <returns>返回HTTP请求对象。</returns>
        public HttpWebRequest CreateHttpWebRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(this._request.URL);
            request.Method = "POST";
            request.Accept = "*/*";
            request.AllowWriteStreamBuffering = false;
            request.KeepAlive = true;
            request.ContentType = this._request.Headers["Content-Type"].ToString();
            request.UserAgent = this._request.UserAgent;
            request.ContentLength = this._request.Buffer.Length;
            request.CookieContainer = _cookieContainer;

            return request;
        }//end method

        /// <summary>
        /// 向流对象中写入Body数据。
        /// </summary>
        /// <param name="requestStream">流对象。</param>
        public void WriteHttpWebRequestStream(Stream requestStream)
        {
            var buffer = this._request.Buffer;

            using (requestStream)
            {
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
            }//end using
        }//end method

        /// <summary>
        /// 创建HTTP响应对象。
        /// </summary>
        /// <returns>返回HTTP响应对象。</returns>
        public HttpWebResponse CreateHttpWebResponse(HttpWebRequest request)
        {
            var response = (HttpWebResponse)request.GetResponse();
            return response;
        }//end method

        /// <summary>
        /// 获取HTTP响应Body中的二进制数据。
        /// </summary>
        /// <param name="response">HTTP响应对象。</param>
        /// <returns>返回二进制数据。</returns>
        public Stream GetResponseStream(HttpWebResponse response)
        {
            return response.GetResponseStream();
        }//end method

        /// <summary>
        /// 获取HTTP响应Body中的字符串数据。
        /// </summary>
        /// <param name="response">HTTP响应对象。</param>
        /// <returns>返回字符串数据。</returns>
        public string GetResponseString(HttpWebResponse response)
        {
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s, this._request.Encoder))
                {
                    return reader.ReadToEnd();
                }//end using
            }//end usng
        }//end method

        #endregion

    }//end class
}//end namespace
