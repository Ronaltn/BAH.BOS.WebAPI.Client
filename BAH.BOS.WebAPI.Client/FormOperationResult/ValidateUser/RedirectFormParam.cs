using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.ValidateUser
{
    [JsonObject]
    public class RedirectFormParam
    {
        [JsonProperty]
        public string FormId { get; internal set; }//end property

        [JsonProperty]
        public string PageId { get; internal set; }//end property

        [JsonProperty]
        public string FormType { get; internal set; }//end property

    }//end class
}//end namespace
