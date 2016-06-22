using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult
{
    [JsonObject]
    public class OperationStatus
    {
        [JsonProperty]
        public string ErrorCode { get; internal set; }//end property
        
        [JsonProperty]
        public string Message { get; internal set; }//end property

        [JsonProperty]
        public string StackTrace { get; internal set; }//end property

        [JsonProperty]
        public bool IsSuccess { get; internal set; }//end property

        [JsonProperty]
        public List<ValidationError> Errors { get; internal set; }//end property
    }//end class
}//end namespace
