using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client
{
    /// <summary>
    /// API操作抽象类扩展。
    /// </summary>
    public static class KdAPIOperationExtension
    {
        /// <summary>
        /// 转向KdAPI请求。
        /// </summary>
        /// <param name="operation">API操作实例。</param>
        /// <returns>返回KdAPI请求对象。</returns>
        public static KdAPIRequest ToKdAPIRequest(this APIOperation operation)
        {
            return operation.ToAPIRequest<KdAPIRequest>();
        }//end method

    }//end class
}//end namespace
