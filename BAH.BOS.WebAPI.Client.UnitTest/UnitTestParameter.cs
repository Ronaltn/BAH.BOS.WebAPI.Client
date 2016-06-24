using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.UnitTest
{
    public class UnitTestParameter : BaseTestParameter
    {
        public override string URL
        {
            get
            {
                return "http://ipv4.fiddler/K3Cloud";
            }
        }

        public override string DBId
        {
            get
            {
                return "5756387562288f";
            }
        }

        public override string UserName
        {
            get
            {
                return "00001";
            }
        }

        public override string Password
        {
            get
            {
                return "888888";
            }
        }

    }
}
