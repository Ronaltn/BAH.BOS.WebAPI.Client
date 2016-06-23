using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.AuthOperationResult
{
    [JsonObject]
    public class Context
    {
        [JsonProperty]
        public string UserLocale { get; set; }

        [JsonProperty]
        public string LogLocale { get; set; }

        [JsonProperty("DBid")]
        public string DBId { get; set; }

        [JsonProperty]
        public DatabaseType DatabaseType { get; set; }

        [JsonProperty]
        public List<LanguageInfo> UseLanguages { get; set; }

        [JsonProperty]
        public int UserId { get; set; }

        [JsonProperty]
        public string UserName { get; set; }

        [JsonProperty]
        public string CustomName { get; set; }

        [JsonProperty]
        public string DisplayVersion { get; set; }

        [JsonProperty]
        public string UserToken { get; set; }

        [JsonProperty]
        public OrganizationInfo CurrentOrganizationInfo { get; set; }

        [JsonProperty]
        public string IsCH_ZH_AutoTrans { get; set; }

        [JsonProperty]
        public ClientType ClientType { get; set; }

        [JsonProperty]
        public KDOAuthInfo WeiboAuthInfo { get; set; }

    }//end class
}//end namespace
