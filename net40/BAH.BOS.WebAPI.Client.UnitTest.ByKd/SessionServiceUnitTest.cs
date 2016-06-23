using BAH.BOS.WebAPI.Client.BusinessOperationResult;
using BAH.BOS.WebAPI.Client.BusinessServiceOperation.SessionService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    //[TestClass]
    public class SessionServiceUnitTest : AuthServiceUnitTest
    {
        [TestMethod]
        public void TestSessionService()
        {
            TestLogin();
            TestHeartbeat();
        }//end method

        [TestMethod]
        public void TestHeartbeat()
        {
            var result = APIClient.CreateAPIOperation<Heartbeat>(TestParameter.URL)
                                  .ToKdAPIRequest()
                                  .ToAPIResponse<ServiceResult>();

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            Assert.IsNull(result.Error);
            Assert.IsNull(result.APIError);
            Assert.IsNotNull(result.Body);
            Assert.IsTrue(result.Body.Code == (int)ResultCode.Success);
        }//end method

    }//end class
}//end namespace
