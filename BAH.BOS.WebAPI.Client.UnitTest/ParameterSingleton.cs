using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    /// <summary>
    /// 测试参数的单例对象。
    /// </summary>
    public static class ParameterSingleton
    {
        /// <summary>
        /// 参数字典。
        /// </summary>
        private static Dictionary<Type, BaseTestParameter> parameters = null;

        /// <summary>
        /// 获取测试参数的实例对象。
        /// </summary>
        /// <typeparam name="T">目标参数类型。</typeparam>
        /// <returns>返回参数实例。</returns>
        public static T GetInstance<T>() where T : BaseTestParameter, new()
        {
            if (parameters == null) parameters = new Dictionary<Type, BaseTestParameter>();
            if (!parameters.Keys.Contains(typeof(T))) parameters.Add(typeof(T), new T());
            return parameters[typeof(T)] as T;
        }//end static method

    }//end static class
}//end namespace
