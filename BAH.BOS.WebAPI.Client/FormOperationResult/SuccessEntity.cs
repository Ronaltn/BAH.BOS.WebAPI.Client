using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult
{
    [JsonObject]
    public class SuccessEntity
    {
        [JsonProperty]
        public string Id { get; internal set; }//end property

        [JsonProperty]
        public string Number { get; internal set; }//end property

        [JsonProperty]
        public string DIndex { get; internal set; }//end property
    }//end class
}//end namespace
