using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BAH.BOS.WebAPI.Client
{
    [JsonObject]
    public class APIExceptionWrapper
    {
        [JsonIgnore]
        public IDictionary Data { get; internal set; }//end property

        [JsonProperty]
        public string ExceptionType { get; internal set; }//end property

        [JsonProperty]
        public string HelpLink { get; internal set; }//end property

        [JsonIgnore]
        public Exception InnerException { get; internal set; }//end property

        [JsonProperty]
        public bool IsEmpty { get; internal set; }//end property

        [JsonProperty]
        public string Message { get; internal set; }//end property

        [JsonProperty]
        public string Source { get; internal set; }//end property

        [JsonProperty]
        public string StackTrace { get; internal set; }//end property

        [JsonProperty]
        public string TargetSite { get; internal set; }//end property

    }//end class
}//end namespace
