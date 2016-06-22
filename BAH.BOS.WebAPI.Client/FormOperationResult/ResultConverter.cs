using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult
{
    [JsonObject]
    public class ResultConverter<T> where T : FormResult
    {
        [JsonProperty]
        public T Result { get; internal set; }//end property
    }//end class
}//end namespace
