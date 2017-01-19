using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.BusinessOperationResult.MCService
{
    /// <summary>
    /// 检测登录会话是否有效的服务返回结果。
    /// </summary>
    [JsonObject]
    public class GetDataCenterListResult : ServiceResult<List<DataCenterInfo>>
    {

    }//end class

    /// <summary>
    /// 数据中心实体信息。
    /// </summary>
    [JsonObject]
    public class DataCenterInfo
    {
        /// <summary>
        /// 数据中心主键。
        /// </summary>
        [JsonProperty]
        public string Id { get; set; }

        /// <summary>
        /// 数据中心编码。
        /// </summary>
        [JsonProperty]
        public string Number { get; set; }

        /// <summary>
        /// 数据中心名称。
        /// </summary>
        [JsonProperty]
        public string Name { get; set; }
    }

}//end namespace
