using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BAH.BOS.WebAPI.Client.AuthServiceOperation;
using BAH.BOS.WebAPI.Client.AuthOperationResult;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    [TestClass]
    public class AuthServiceUnitTest
    {
        [TestMethod]
        public void TestLogin()
        {
            var parameter = ParameterSingleton.GetInstance();
            var context = APIClient.CreateAPIOperation<Login>(parameter.URL)
                                  .SetDBId(parameter.DBId)
                                  .SetUserName(parameter.UserName)
                                  .SetPassword(parameter.Password)
                                  .ToKdAPIRequest()
                                  .ToAPIResponse<Context>();
        }//end method

    }//end class
}//end namespace
