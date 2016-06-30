using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.BusinessServiceOperation
{
    /// <summary>
    /// 执行不依赖于表单的服务操作。
    /// </summary>
    public class ExecuteServiceOperation : APIOperation
    {
        #region 公共覆盖操作参数

        /// <summary>
        /// 操作的服务名称定义。
        /// </summary>
        public override string ServiceName
        {
            get
            {
                return string.Format("{0}.{1},{2}", this.ClassName, this.MethodName, this.AssemblyName);
            }
        }//end property

        /// <summary>
        /// 操作的请求参数。
        /// </summary>
        public override string RequestParameters
        {
            get
            {
                return this.Parameters == null ? JsonConvert.SerializeObject(new List<object>()) : JsonConvert.SerializeObject(this.Parameters);
            }
        }//end property

        #endregion

        #region 公共操作参数属性

        /// <summary>
        /// 读写程序集名称属性值
        /// </summary>
        public virtual string AssemblyName { get; set; }//end property

        /// <summary>
        /// 读写类名称属性值。
        /// </summary>
        public virtual string ClassName { get; set; }//end property

        /// <summary>
        /// 读写方法名称属性值。
        /// </summary>
        public virtual string MethodName { get; set; }//end property

        /// <summary>
        /// 读写参数集合属性值。
        /// </summary>
        public virtual List<object> Parameters { get; set; }//end property

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置程序集名称。
        /// </summary>
        /// <param name="assemblyName">程序集名称。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteServiceOperation SetAssemblyName(string assemblyName)
        {
            this.AssemblyName = assemblyName;
            return this;
        }//end method

        /// <summary>
        /// 设置类名称，该名称包含前置的命名空间。
        /// </summary>
        /// <param name="className">类名称。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteServiceOperation SetClassName(string className)
        {
            this.ClassName = className;
            return this;
        }//end method

        /// <summary>
        /// 设置类名称，在该名称之前自动加上已设置的程序集名称作为命名空间。
        /// </summary>
        /// <param name="className">不含有前置命名空间的类名称。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteServiceOperation SetClassNameWithoutNamespace(string className)
        {
            this.ClassName = string.Format("{0}.{1}", this.AssemblyName, className);
            return this;
        }//end method

        /// <summary>
        /// 设置方法名称。
        /// </summary>
        /// <param name="methodName">方法名称。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteServiceOperation SetMethodName(string methodName)
        {
            this.MethodName = methodName;
            return this;
        }//end method

        /// <summary>
        /// 设置方法执行需要的参数集合。
        /// </summary>
        /// <param name="parameters">参数集合。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteServiceOperation SetParameters(List<object> parameters)
        {
            this.Parameters = parameters;
            return this;
        }//end method

        /// <summary>
        /// 添加方法执行需要的参数。
        /// </summary>
        /// <param name="parameter">单个参数对象。</param>
        /// <returns>返回类本身实例对象。</returns>
        public virtual ExecuteServiceOperation AddParamater(object parameter)
        {
            if (this.Parameters == null)
            {
                this.Parameters = new List<object>();
            }//end if

            this.Parameters.Add(parameter);
            return this;
        }//end method

        #endregion

    }//end class
}//end namespace
