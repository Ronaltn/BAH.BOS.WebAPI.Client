using BAH.BOS.WebAPI.Client.FormOperationResult;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.View
{
    [JsonObject]
    public class ViewOperationResult<T> : Result
    {
        [JsonProperty]
        public T Result { get; internal set; }//end property
    }//end class
}//end namespace
