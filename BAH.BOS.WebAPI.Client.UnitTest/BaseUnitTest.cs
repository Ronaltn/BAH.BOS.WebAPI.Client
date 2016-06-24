using BAH.BOS.WebAPI.Client.AuthOperationResult;
using BAH.BOS.WebAPI.Client.AuthServiceOperation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    /// <summary>
    /// 单元测试基类。
    /// </summary>
    /// <typeparam name="T">测试参数泛型定义。</typeparam>
    public abstract class BaseUnitTest<T> where T : BaseTestParameter, new()
    {
        /// <summary>
        /// 测试参数属性。
        /// </summary>
        public virtual T TestParameter 
        {
            get { return ParameterSingleton.GetInstance<T>(); }
        }

        /// <summary>
        /// 实现登录。
        /// </summary>
        /// <returns>返回API结果。</returns>
        public virtual APIResponse<LoginResult> Login()
        {
            var result = APIClient.CreateAPIOperation<Login>(this.TestParameter.URL)
                                  .SetDBId(this.TestParameter.DBId)
                                  .SetUserName(this.TestParameter.UserName)
                                  .SetPassword(this.TestParameter.Password)
                                  .ToKdAPIRequest()
                                  .ToAPIResponse<LoginResult>();
            return result;
        }

    }//end class
}//end namespace
