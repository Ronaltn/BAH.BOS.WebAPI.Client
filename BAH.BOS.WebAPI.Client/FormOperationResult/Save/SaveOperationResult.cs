using BAH.BOS.WebAPI.Client.FormOperationResult;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.Save
{
    [JsonObject]
    public class SaveOperationResult : Result
    {
        [JsonProperty]
        public string Id { get; internal set; }//end property

        [JsonProperty]
        public string Number { get; internal set; }//end property
    }//end class
}//end namespace
