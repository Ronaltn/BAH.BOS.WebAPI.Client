using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    public class BaseUnitTest
    {
        public UnitTestParameter TestParameter
        {
            get { return ParameterSingleton.GetInstance(); }
        }//end property

    }//end class
}//end namespace
