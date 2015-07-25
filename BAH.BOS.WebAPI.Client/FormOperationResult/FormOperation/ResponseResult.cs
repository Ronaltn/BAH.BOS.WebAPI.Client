using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.FormOperation
{
    [JsonObject]
    public class ResponseResult
    {
        [JsonProperty]
        public ResponseStatus ResponseStatus { get; internal set; }//end property
    }//end class
}//end namespace
