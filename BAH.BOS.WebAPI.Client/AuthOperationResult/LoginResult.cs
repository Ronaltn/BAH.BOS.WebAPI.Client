using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.AuthOperationResult
{
    [JsonObject]
    public class ValidateUserResult
    {
        [JsonProperty]
        public string Message { get; set; }//end property

        [JsonProperty]
        public string MessageCode { get; set; }//end property

        [JsonProperty]
        public LoginResultType LoginResultType { get; set; }//end property

        [JsonProperty]
        public Context Context { get; set; }//end property

        [JsonProperty]
        public string FormId { get; set; }//end property

        [JsonProperty]
        public RedirectFormParam RedirectFormParam { get; set; }//end property

        [JsonProperty]
        public object FormInputObject { get; set; }//end property

        [JsonProperty]
        public string ErrorStackTrace { get; set; }//end property

        [JsonProperty("Lcid")]
        public int LCID { get; set; }//end property
    }//end class
}//end namespace
