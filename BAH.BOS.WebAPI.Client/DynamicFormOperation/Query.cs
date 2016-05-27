using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.DynamicFormOperation
{
    /// <summary>
    /// 执行查询操作。
    /// </summary>
    public class Query : FormOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.ExecuteBillQuery";
            }
        }//end property

        /// <summary>
        /// 操作的请求参数。
        /// </summary>
        public override string RequestParameters
        {
            get
            {
                var parametersArray = new object[]
                {
                    new 
                    {
                        FormId = this.DynamicFormViewId,
                        TopRowCount = this.TopRowCount,
                        Limit = this.PageRowCount,
                        StartRow = this.PageIndex,
                        FilterString = this.Filter,
                        OrderString = this.OrderBy,
                        FieldKeys = string.Join(",", this.FieldKeys)
                    }
                };

                return JsonConvert.SerializeObject(parametersArray);
            }
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写最多允许查询的数量属性值。
        /// </summary>
        /// <remarks>
        /// 0或者不要此属性表示不限制。
        /// </remarks>
        public virtual int TopRowCount { get; set; }//end property

        /// <summary>
        /// 读写分页取数每页允许获取的数据属性值。
        /// </summary>
        /// <remarks>
        /// 最大不能超过2000。
        /// </remarks>
        public virtual int PageRowCount { get; set; }//end property

        /// <summary>
        /// 读写分页取数开始行索引属性值。
        /// </summary>
        /// <remarks>
        /// 从0开始，例如每页10行数据，第2页开始是10，第3页开始是20，以此类推，当不提供此属性，表示仅查询Limit中填写的数据量。
        /// </remarks>
        public virtual int PageIndex { get; set; }//end property

        /// <summary>
        /// 读写过滤条件属性值。
        /// </summary>
        public virtual string Filter { get; set; }//end property

        /// <summary>
        /// 读写排序条件属性值。
        /// </summary>
        public virtual string OrderBy { get; set; }//end property

        /// <summary>
        /// 读写表单返回数据字段的索引键属性值。
        /// </summary>
        public virtual List<string> FieldKeys { get; set; }//end property

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置读写动态表单类型标识。
        /// </summary>
        /// <param name="dynamicFormViewId">动态表单类型标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Query SetDynamicFormViewId(string dynamicFormViewId)
        {
            return this.SetDynamicFormViewId<Query>(dynamicFormViewId);
        }//end method

        /// <summary>
        /// 设置最多允许查询的单据数量。
        /// </summary>
        /// <param name="count">单据数量值。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Query SetTopRowCount(int topRowCount)
        {
            this.TopRowCount = topRowCount;
            return this;
        }//end method

        /// <summary>
        /// 设置分页取数每页允许获取的单据数量。
        /// </summary>
        /// <param name="pageRowCount">分页数量值。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Query SetPageRowCount(int pageRowCount)
        {
            this.PageRowCount = pageRowCount;
            return this;
        }//end method

        /// <summary>
        /// 设置分页取数开始行索引。
        /// </summary>
        /// <param name="pageIndex">索引值。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Query SetPageIndex(int pageIndex)
        {
            this.PageIndex = pageIndex;
            return this;
        }//end method

        /// <summary>
        /// 设置过滤条件。
        /// </summary>
        /// <param name="filter">过滤条件。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Query SetFilter(string filter)
        {
            this.Filter = filter;
            return this;
        }//end method

        /// <summary>
        /// 设置排序条件。
        /// </summary>
        /// <param name="orderBy">排序条件。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Query SetOrderBy(string orderBy)
        {
            this.OrderBy = orderBy;
            return this;
        }//end method

        /// <summary>
        /// 表单返回数据字段。
        /// </summary>
        /// <param name="fieldKey">字段索引键。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Query AddFieldKey(string fieldKey)
        {
            if (this.FieldKeys == null)
            {
                this.FieldKeys = new List<string>();
            }//end if

            this.FieldKeys.Add(fieldKey);
            return this;
        }//end method

        #endregion

    }//end class
}//end namespace
