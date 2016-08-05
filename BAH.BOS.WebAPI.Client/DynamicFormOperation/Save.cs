using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.DynamicFormOperation
{
    /// <summary>
    /// 执行保存操作。
    /// </summary>
    public class Save : FormOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save";
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
                        Creator = string.IsNullOrEmpty(this.Creator) ? "BAH" : this.Creator,
                        NeedUpDateFields = this.NeedUpdateFieldKeys,
                        NumberSearch = (this.BDSetter == BaseDataSetter.Number),
                        Model = this.Model
                    }
                };

                return JsonConvert.SerializeObject(parametersArray);
            }//end get
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写第三方调用者标识。
        /// </summary>
        public virtual string Creator { get; set; }//end property

        /// <summary>
        /// 读写需要更新的字段键值集合。
        /// </summary>
        public virtual List<string> NeedUpdateFieldKeys { get; set; }//end property

        /// <summary>
        /// 基础资料赋值方式。
        /// </summary>
        public enum BaseDataSetter
        {
            /// <summary>
            /// 根据主键赋值。
            /// </summary>
            ID,

            /// <summary>
            /// 根据编码赋值。
            /// </summary>
            Number
        }//end enum

        /// <summary>
        /// 读写基础资料赋值方式。
        /// </summary>
        public virtual BaseDataSetter BDSetter { get; set; }//end property

        /// <summary>
        /// 读写待保存的数据对象。
        /// </summary>
        public virtual object Model { get; set; }//end property

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置读写动态表单类型标识。
        /// </summary>
        /// <param name="dynamicFormViewId">动态表单类型标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Save SetDynamicFormViewId(string dynamicFormViewId)
        {
            return SetDynamicFormViewId<Save>(dynamicFormViewId);
        }//end method

        /// <summary>
        /// 设置第三方调用者标识，
        /// 可不用设置，默认为BAH。
        /// </summary>
        /// <param name="creator">第三方调用者标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Save SetCreator(string creator)
        {
            this.Creator = creator;
            return this;
        }//end method

        /// <summary>
        /// 设置需要更新的字段键值集合。
        /// </summary>
        /// <param name="needUpdateFieldKeys">需要更新的字段键值集合。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Save SetNeedUpdateFieldKeys(List<string> needUpdateFieldKeys)
        {
            this.NeedUpdateFieldKeys = needUpdateFieldKeys;
            return this;
        }//end method

        /// <summary>
        /// 添加需要更新的字段键值。
        /// </summary>
        /// <param name="fieldKey">需要更新的字段键值。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Save AddNeedUpdateFieldKey(string fieldKey)
        {
            if (this.NeedUpdateFieldKeys == null)
            {
                this.NeedUpdateFieldKeys = new List<string>();
            }//end if

            this.NeedUpdateFieldKeys.Add(fieldKey);
            return this;
        }//end method

        /// <summary>
        /// 设置基础资料赋值方式。
        /// </summary>
        /// <param name="setter">赋值方式。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Save SetBDSetter(BaseDataSetter setter)
        {
            this.BDSetter = setter;
            return this;
        }//end method

        /// <summary>
        /// 设置待保存的数据对象。
        /// </summary>
        /// <typeparam name="T">返回类型泛型定义。</typeparam>
        /// <param name="model">待保存的数据对象。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual T SetModel<T>(object model) where T : APIOperation
        {
            this.Model = model;
            return this as T;
        }//end method

        /// <summary>
        /// 设置待保存的数据对象。
        /// </summary>
        /// <param name="model">待保存的数据对象。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual Save SetModel(object model)
        {
            return this.SetModel<Save>(model);
        }//end method

        #endregion

    }//end class
}//end namespace
