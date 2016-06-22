using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.AuthOperationResult
{
    [JsonObject]
    public class KDOAuthInfo
    {
        [JsonProperty]
        public string WeiboUrl { get; internal set; }//end property

        [JsonProperty]
        public string NetWorkID { get; internal set; }//end property

        [JsonProperty]
        public string CompanyNetworkID { get; internal set; }//end property

        [JsonProperty]
        public string Account { get; internal set; }//end property

        [JsonProperty]
        public string AppKey { get; internal set; }//end property

        [JsonProperty]
        public string AppSecret { get; internal set; }//end property

        [JsonProperty]
        public string TokenKey { get; internal set; }//end property

        [JsonProperty]
        public string TokenSecret { get; internal set; }//end property

        [JsonProperty]
        public string Verify { get; internal set; }//end property

        [JsonProperty]
        public string CallbackUrl { get; internal set; }//end property

        [JsonProperty]
        public string UserId { get; internal set; }//end property

        [JsonIgnore]
        public Encoding Charset { get; internal set; }//end property
    }//end class
}//end namespace
