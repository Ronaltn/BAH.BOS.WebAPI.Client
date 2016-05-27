using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.DynamicFormOperation
{
    /// <summary>
    /// 执行查看操作。
    /// </summary>
    public class View : FormOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.View";
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
                    this.DynamicFormViewId,
                    new { CreateOrgId = this.CreateOrgId, Number = this.Number, Id = this.Id }
                };

                return JsonConvert.SerializeObject(parametersArray);
            }
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写创建（主业务）组织标识属性值。
        /// </summary>
        public virtual long CreateOrgId { get; set; }

        /// <summary>
        /// 读写单据（基础资料）主键属性值
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 读写单据（基础资料）编号属性值。
        /// </summary>
        public virtual string Number { get; set; }

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置读写动态表单类型标识。
        /// </summary>
        /// <param name="dynamicFormViewId">动态表单类型标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual View SetDynamicFormViewId(string dynamicFormViewId)
        {
            return SetDynamicFormViewId<View>(dynamicFormViewId);
        }//end method

        /// <summary>
        /// 设置创建（主业务）组织标识。
        /// </summary>
        /// <param name="createOrgId">创建（主业务）组织标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public View SetCreateOrgId(long createOrgId)
        {
            this.CreateOrgId = createOrgId;
            return this;
        }//end method

        /// <summary>
        /// 设置单据（基础资料）主键。
        /// </summary>
        /// <param name="id">单据（基础资料）主键。</param>
        /// <returns>返回类本身实例对象。</returns>
        public View SetId(string id)
        {
            this.Id = id;
            return this;
        }//end method

        /// <summary>
        /// 设置单据（基础资料）编号
        /// </summary>
        /// <param name="number">单据（基础资料）编号。</param>
        /// <returns>返回类本身实例对象。</returns>
        public View SetNumber(string number)
        {
            this.Number = number;
            return this;
        }//end method

        #endregion

    }//end class
}//end namespace
