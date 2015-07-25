using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.ValidateUser
{
    [JsonObject]
    public class ValidateUserResult
    {
        [JsonProperty]
        public string Message { get; internal set; }//end property

        [JsonProperty]
        public LoginResultType LoginResultType { get; internal set; }//end property

        [JsonProperty]
        public Context Context { get; internal set; }//end property

        [JsonProperty]
        public string FormId { get; internal set; }//end property

        [JsonProperty]
        public RedirectFormParam RedirectFormParam { get; internal set; }//end property

        [JsonProperty]
        public object FormInputObject { get; internal set; }//end property

        [JsonProperty]
        public string ErrorStackTrace { get; internal set; }//end property
    }//end class
}//end namespace
