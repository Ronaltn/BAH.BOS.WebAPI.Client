using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.ValidateUser
{
    [JsonObject]
    public class Context
    {
        [JsonProperty]
        public ClientType ClientType { get; internal set; }//end property

        [JsonProperty]
        public OrganizationInfo CurrentOrganizationInfo { get; internal set; }//end property

        [JsonProperty]
        public string CustomName { get; internal set; }//end property

        [JsonProperty]
        public DatabaseType DatabaseType { get; internal set; }//end property

        [JsonProperty]
        public string DBId { get; internal set; }//end property

        [JsonProperty]
        public bool IsCH_ZH_AutoTrans { get; internal set; }//end property

        [JsonProperty]
        public CultureInfo LogLocale { get; internal set; }//end property

        [JsonProperty]
        public List<LanguageInfo> UseLanguages { set; internal get; }//end property

        [JsonProperty]
        public long UserId { set; internal get; }//end property

        [JsonProperty]
        public CultureInfo UserLocale { set; internal get; }//end property

        [JsonProperty]
        public string UserName { get; internal set; }//end property

        [JsonProperty]
        public string UserToken { get; internal set; }//end property

        [JsonProperty]
        public KDOAuthInfo WeiboAuthInfo { get; internal set; }//end property

    }//end class
}//end namespace
