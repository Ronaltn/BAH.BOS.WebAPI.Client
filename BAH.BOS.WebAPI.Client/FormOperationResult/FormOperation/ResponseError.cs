using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.FormOperation
{
    [JsonObject]
    public class ResponseError
    {
        [JsonProperty]
        public string ErrorCode { get; internal set; }//end property

        [JsonProperty]
        public string FieldName { get; internal set; }//end property

        [JsonProperty]
        public string Message { get; internal set; }//end property
    }//end class
}//end namespace
