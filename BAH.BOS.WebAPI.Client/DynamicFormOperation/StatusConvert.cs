using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.DynamicFormOperation
{
    /// <summary>
    /// 支持单据的作废操作，
    /// 支持基础资料的禁用、反禁用操作。
    /// </summary>
    public class StatusConvert : SingleActionOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.StatusConvert";
            }
        }//end property

        #endregion

    }//end class
}//end namespace
