using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// API请求对象，包含有Header部分和Body部分。
    /// </summary>
    public class APIRequest
    {
        #region 私有域

        private string _format;
        private string _useragent;
        private string _rid;
        private string _parameters;
        private string _timestamp;
        private string _v;

        private string _encoderName;

        #endregion

        #region 公共属性

        #region Json序列化属性(Body)

        /// <summary>
        /// 请求参数，格式化，默认为1
        /// </summary>
        [JsonProperty("format")]
        public string Format
        {
            get
            {
                return _format; 
            }
            private set
            {
                _format = value;
            }
        }//end property

        /// <summary>
        /// 请求参数，会话代理，默认为ApiClient
        /// </summary>
        [JsonProperty("useragent")]
        public string UserAgent
        {
            get
            {
                return _useragent;
            }
            private set
            {
                _useragent = value;
            }
        }//end property

        /// <summary>
        /// 请求参数，访问ID，默认由GUID生成
        /// </summary>
        [JsonProperty("rid")]
        public string RequestId
        {
            get
            {
                return _rid;
            }
            private set
            {
                _rid = value;
            }
        }//end property

        /// <summary>
        /// 请求参数，针对操作需要传入的参数，由调用者提供
        /// </summary>
        [JsonProperty("parameters")]
        public string Parameters
        {
            get
            {
                return _parameters;
            }//end get
            set
            {
                _parameters = value;
            }
        }//end property

        /// <summary>
        /// 请求参数，时间戳，默认为当前时间
        /// </summary>
        [JsonProperty("timestamp")]
        public string TimeStamp
        {
            get
            {
                return _timestamp;
            }
            private set
            {
                _timestamp = value;
            }
        }//end property

        /// <summary>
        /// 请求参数，版本号，默认为1.0
        /// </summary>
        [JsonProperty("v")]
        public string Version
        {
            get
            {
                return _v;
            }
            private set
            {
                _v = value;
            }
        }//end property

        #endregion

        #region Json不序列化属性

        /// <summary>
        /// 通过构造方法接收到的API操作对象。
        /// </summary>
        [JsonIgnore]
        public APIOperation Operation { get; private set; }//end property

        /// <summary>
        /// HTTP发起请求完整的URL
        /// </summary>
        [JsonIgnore]
        public string URL { get; set; }//end property

        /// <summary>
        /// HTTP请求的编码格式，默认为UTF8。
        /// </summary>
        [JsonIgnore]
        public Encoding Encoder { get; set; }//end property

        /// <summary>
        /// HTTP请求的Header部分
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, object> Headers { get; protected set; }//end property

        /// <summary>
        /// HTTP请求的Body部分字符串
        /// </summary>
        [JsonIgnore]
        public string Body
        {
            get
            {
                return JsonConvert.SerializeObject(this);
            }
        }//end property

        /// <summary>
        /// HTTP请求的Body部分二进制
        /// </summary>
        [JsonIgnore]
        public byte[] Buffer
        {
            get
            {
                return this.Encoder.GetBytes(this.Body);
            }
        }//end property

        #endregion

        #endregion

        #region 构造方法

        /// <summary>
        /// 默认构造方法，给部分属性设置默认值，除了URL和Parameters。
        /// </summary>
        public APIRequest()
        {
            this.SetDefaultValue();
        }//end constructor

        /// <summary>
        /// 构造方法，只需要传入URL和文本参数即可，其它参数一般无需理会。
        /// </summary>
        /// <param name="url">URL。</param>
        /// <param name="parameters">文本字符串，一般是Json序列化后的字符串。</param>
        public APIRequest(string url, string parameters)
        {
            this.URL = url;
            this.Parameters = parameters;

            this.SetDefaultValue();
        }//end constructor

        /// <summary>
        /// 构造方法，将APIOperation实例对象传入生成一个APIRequest对象。
        /// </summary>
        /// <param name="operation">APIOperation实例对象。</param>
        public APIRequest(APIOperation operation)
        {
            this.Operation = operation;

            this.URL = operation.RequestUrl;
            this.Parameters = operation.RequestParameters;

            this.SetDefaultValue();
        }//end constructor

        #endregion

        #region 公共方法

        /// <summary>
        /// 将APIOperation实例对象传入生成一个APIRequest对象。
        /// </summary>
        /// <typeparam name="T">指定的类型，该类型继承APIRequest。</typeparam>
        /// <param name="operation">APIOperation实例对象。</param>
        /// <returns>返回指定的类型实例对象，该类型继承APIRequest。</returns>
        public T SetOperation<T>(APIOperation operation) where T : APIRequest
        {
            this.Operation = operation;
            this.URL = operation.RequestUrl;
            this.Parameters = operation.RequestParameters;

            return this as T;
        }//end method

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置部分属性的默认值。
        /// </summary>
        private void SetDefaultValue()
        {
            this.Format = "1";
            this.UserAgent = "ApiClient";
            this.Encoder = Encoding.UTF8;
            this.RequestId = Guid.NewGuid().ToString().GetHashCode().ToString();
            this.Version = "1.0";
            this.TimeStamp = DateTime.Now.ToFileTime().ToString();

            this.Headers = new Dictionary<string, object>();
            this.Headers.Add("Content-Type", "application/json");
        }//end method

        #endregion

    }//end class
}//end namespace
