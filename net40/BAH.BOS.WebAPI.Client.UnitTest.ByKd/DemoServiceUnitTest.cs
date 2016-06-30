using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BAH.BOS.WebAPI.Client.BusinessServiceOperation;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    [TestClass]
    public class DemoServiceUnitTest : BaseUnitTest<UnitTestParameter>
    {
        [TestMethod]
        public virtual void TestDemoService()
        {
            this.TestHelloWorld();
            this.TestHelloUser();
        }

        public virtual void TestHelloWorld()
        {
            var response = APIClient.CreateAPIOperation<ExecuteServiceOperation>(this.TestParameter.URL)
                                    .SetClassName("BAH.BOS.WebAPI.ServiceStub")
                                    .SetClassNameWithoutNamespace("Demo.DemoService")
                                    .SetMethodName("HelloWorld")
                                    .ToKdAPIRequest()
                                    .ToAPIResponse<string>();
        }

        public virtual void TestHelloUser()
        {
            var response = APIClient.CreateAPIOperation<ExecuteServiceOperation>(this.TestParameter.URL)
                                    .SetClassName("BAH.BOS.WebAPI.ServiceStub")
                                    .SetClassNameWithoutNamespace("Demo.DemoService")
                                    .SetMethodName("HelloUser")
                                    .ToKdAPIRequest()
                                    .ToAPIResponse<string>();
        }

    }//end class
}//end namespace
