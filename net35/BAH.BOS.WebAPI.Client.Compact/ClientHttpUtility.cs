using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using BAH.BOS.WebAPI.Client.DynamicFormOperation;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// 客户端自定义的HTTP访问组件。
    /// </summary>
    public class ClientHttpUtility
    {
        #region 私有域

        /// <summary>
        /// 
        /// </summary>
        private APIRequest _request = null;

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法，传入API请求对象。
        /// </summary>
        /// <param name="request">API请求对象。</param>
        public ClientHttpUtility(APIRequest request)
        {
            this._request = request;
        }//end method

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
            GetCookie(request);

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
            SaveCookie(response);
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

        /// <summary>
        /// 拆解Cookie数据，去除无用的信息，得到其中有用的信息。
        /// </summary>
        /// <param name="response">HTTP响应对象。</param>
        /// <returns>返回经过拆解处理的Cookie数据。</returns>
        public string SplitCookie(HttpWebResponse response)
        {
            StringBuilder cookie = new StringBuilder();
            var setCookie = response.Headers["Set-Cookie"];
            var array = setCookie.Split(new char[] { ',' });
            foreach (var item in array)
            {
                cookie.Append(item.Substring(0, item.IndexOf(";") + 1));
                cookie.Append(" ");
            }//end foreach

            if (cookie.Length >= 2)
            {
                cookie.Remove(cookie.Length - 2, 2);
            }//end if

            return cookie.ToString();
        }//end method

        /// <summary>
        /// 从进程中取出Cookie信息并赋予给HTTP请求对象。
        /// </summary>
        /// <param name="response">HTTP响应对象。</param>
        public void GetCookie(HttpWebRequest request)
        {
            //执行其他操作（非验证用户）时，读取本地Cookie
            if (!string.Equals(this._request.Operation.ServiceName, new ValidateUser().ServiceName,
                StringComparison.OrdinalIgnoreCase))
            {
                var cookie = CookieManager.Get(this._request.Operation.RootUrl);
                request.Headers.Add("Cookie", cookie);
            }//end if
        }//end method

        /// <summary>
        /// 将HTTP响应对象中的Cookie信息保存在进程中。
        /// </summary>
        /// <param name="response">HTTP响应对象。</param>
        public void SaveCookie(HttpWebResponse response)
        {
            //执行验证用户时，获取并保存Cookie
            if (string.Equals(this._request.Operation.ServiceName, new ValidateUser().ServiceName,
                StringComparison.OrdinalIgnoreCase))
            {
                var cookie = SplitCookie(response);
                CookieManager.Save(this._request.Operation.RootUrl, cookie);
            }//end if
        }//end method

        #endregion

    }//end class
}//end namespace
