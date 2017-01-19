using BAH.BOS.WebAPI.Client.BusinessOperationResult;
using BAH.BOS.WebAPI.Client.BusinessOperationResult.MCService;
using BAH.BOS.WebAPI.Client.BusinessOperationResult.SessionService;
using BAH.BOS.WebAPI.Client.BusinessServiceOperation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    [TestClass]
    public class MCServiceUnitTest : BaseUnitTest<UnitTestParameter>
    {
        [TestMethod]
        public virtual void TestMCService()
        {
            this.TestGetDataCenterList();
        }//end method

        public virtual void TestGetDataCenterList()
        {
            var result = APIClient.CreateAPIOperation<MCService>(this.TestParameter.URL)
                                  .GetDataCenterList()
                                  .ToKdAPIRequest()
                                  .ToAPIResponse<GetDataCenterListResult>();
        }//end method

    }//end class
}//end namespace
