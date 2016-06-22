using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.AuthOperationResult
{
    [JsonObject]
    public class LanguageInfo
    {
        [JsonProperty]
        public string Alias { set; internal get; }//end property

        [JsonProperty]
        public int LocaleId { set; internal get; }//end property

        [JsonProperty]
        public string LocaleName { set; internal get; }//end property

    }//end class
}//end namespace
