using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// API操作抽象类扩展。
    /// </summary>
    public static class UnirestAPIOperationExtension
    {
        /// <summary>
        /// 转向KdAPI请求。
        /// </summary>
        /// <param name="operation">API操作实例。</param>
        /// <returns>返回KdAPI请求对象。</returns>
        public static UnirestAPIRequest ToUnirestAPIRequest(this APIOperation operation)
        {
            return operation.ToAPIRequest<UnirestAPIRequest>();
        }//end method

    }//end class
}//end namespace
