using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.DynamicFormOperation
{
    /// <summary>
    /// 执行表单操作。
    /// </summary>
    public class ExecuteFormOperation : FormOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.ExcuteOperation";
            }
        }//end property

        /// <summary>
        /// 操作的请求参数。
        /// </summary>
        public override string RequestParameters
        {
            get
            {
                var parametersArray = new object[]{
                    this.ObjectTypeId,
                    this.OperationNumber,
                    new { Parameters = this.Parameters, Model = this.Model }
                };

                return JsonConvert.SerializeObject(parametersArray);
            }
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写操作编码属性值
        /// </summary>
        public virtual string OperationNumber { get; set; }//end property

        /// <summary>
        /// 读写操作参数属性值，对应服务端的参数键Parameters。
        /// </summary>
        public virtual string Parameters { get; set; }//end property

        /// <summary>
        /// 读写操作单据数据对象属性值。
        /// </summary>
        public virtual object Model { get; set; }//end property

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置读写动态表单类型标识。
        /// </summary>
        /// <param name="objectTypeId">动态表单类型标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteFormOperation SetObjectTypeId(string objectTypeId)
        {
            return SetObjectTypeId<ExecuteFormOperation>(objectTypeId);
        }//end method

        /// <summary>
        /// 设置操作编码。
        /// </summary>
        /// <param name="operationNumber">操作编码。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteFormOperation SetOperationNumber(string operationNumber)
        {
            this.OperationNumber = operationNumber;
            return this;
        }//end method

        /// <summary>
        /// 设置操作参数。
        /// </summary>
        /// <param name="operationParameters">操作参数。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteFormOperation SetParameters(string operationParameters)
        {
            this.Parameters = operationParameters;
            return this;
        }//end method

        /// <summary>
        /// 设置单据数据。
        /// </summary>
        /// <param name="model">单据数据。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteFormOperation SetModel(object model)
        {
            this.Model = model;
            return this;
        }//end method

        #endregion

    }//end class
}//end namespace
