using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.DynamicFormOperation
{
    /// <summary>
    /// 执行批量保存操作。
    /// </summary>
    public class BatchSave : Save
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.BatchSave";
            }
        }//end property

        /// <summary>
        /// 待保存的数据对象。
        /// </summary>
        public override string RequestParameters
        {
            get
            {
                var parametersArray = new object[]{
                    this.DynamicFormViewId,
                    new 
                    { 
                        Creator = string.IsNullOrEmpty(this.Creator) ? "BAH" : this.Creator , 
                        NeedUpDateFields = this.NeedUpdateFieldKeys, 
                        Model = this.Models 
                    }
                };

                return JsonConvert.SerializeObject(parametersArray);
            }
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写待保存的数据对象。
        /// </summary>
        public override object Model
        {
            get
            {
                return this.Models == null ? null : this.Models.FirstOrDefault();
            }
            set
            {
                if (this.Models == null)
                {
                    this.Models = new List<object>();
                }//end if
                this.Models.Add(value);
            }
        }//end property

        /// <summary>
        /// 读写待保存的多个数据对象。
        /// </summary>
        public virtual List<object> Models { get; set; }//end property

        #endregion

        #region 公共方法

        /// <summary>
        /// 添加待保存的数据对象。
        /// </summary>
        /// <param name="model">待保存的数据对象。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual BatchSave AddModel(object model)
        {
            if (this.Models == null)
            {
                this.Models = new List<object>();
            }//end if
            this.Models.Add(model);
            return this;
        }//end method

        /// <summary>
        /// 设置待保存的数据对象，但无论执行多少次只会保留最后一次设置的数据对象。
        /// </summary>
        /// <param name="model">待保存的数据对象。</param>
        /// <returns>返回类本身实例对象。</returns>
        new public virtual BatchSave SetModel(object model)
        {
            return this.SetModel<BatchSave>(model);
        }//end method

        #endregion

    }//end class
}//end namespace
