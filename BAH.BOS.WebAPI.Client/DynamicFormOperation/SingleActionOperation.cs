using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.DynamicFormOperation
{
    /// <summary>
    /// 单个动作操作抽象类，
    /// 简单的意义在于操作只接收编号参数，通常进行形态转换相关的动作。
    /// </summary>
    public abstract class SingleActionOperation : FormOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的请求参数。
        /// </summary>
        public override string RequestParameters
        {
            get
            {
                var parametersArray = new object[]{
                    this.ObjectTypeId,
                    new { CreateOrgId = this.CreateOrgId, Numbers = this.Numbers.ToArray<string>() }
                };

                return JsonConvert.SerializeObject(parametersArray);
            }//end get
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写创建（主业务）组织标识属性值。
        /// </summary>
        public virtual long CreateOrgId { get; set; }

        /// <summary>
        /// 读写单据（基础资料）编号属性值。
        /// </summary>
        public virtual List<string> Numbers { get; set; }

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置动态表单类型标识。
        /// </summary>
        /// <param name="objectTypeId">动态表单类型标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual SingleActionOperation SetObjectTypeId(string objectTypeId)
        {
            return SetObjectTypeId<SingleActionOperation>(objectTypeId);
        }//end method

        /// <summary>
        /// 设置创建（主业务）组织标识。
        /// </summary>
        /// <typeparam name="T">继承APISimpleOperation的类。</typeparam>
        /// <param name="createOrgId">创建（主业务）组织标识。</param>
        /// <returns>返回T定义类型的实例对象。</returns>
        public virtual T SetCreateOrgId<T>(long createOrgId) where T : SingleActionOperation
        {
            this.CreateOrgId = createOrgId;
            return this as T;
        }//end method

        /// <summary>
        /// 设置创建（主业务）组织标识。
        /// </summary>
        /// <param name="createOrgId">创建（主业务）组织标识。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual SingleActionOperation SetCreateOrgId(long createOrgId)
        {
            return SetCreateOrgId<SingleActionOperation>(createOrgId);
        }//end method

        /// <summary>
        /// 设置单据（基础资料）编号。
        /// </summary>
        /// <typeparam name="T">继承APISimpleOperation的类。</typeparam>
        /// <param name="numbers">单据（基础资料）编号。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual T SetNumbers<T>(List<string> numbers) where T : SingleActionOperation
        {
            this.Numbers = numbers;
            return this as T;
        }//end method

        /// <summary>
        /// 设置单据（基础资料）编号集合。
        /// </summary>
        /// <param name="numbers">单据（基础资料）编号集合。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual SingleActionOperation SetNumbers(List<string> numbers)
        {
            return SetNumbers<SingleActionOperation>(numbers);
        }//end method

        /// <summary>
        /// 添加单据（基础资料）编号。
        /// </summary>
        /// <param name="number">单据（基础资料）编号。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual SingleActionOperation AddNumber(string number)
        {
            if (this.Numbers == null)
            {
                this.Numbers = new List<string>();
            }//end if

            this.Numbers.Add(number);
            return this;
        }//end method

        #endregion

    }//end class
}//end namespace
