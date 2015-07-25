using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.ValidateUser
{
    public enum LoginResultType
    {
        DealWithForm = -5,
        Wanning = -4,
        PWInvalid_Required = -3,
        PWInvalid_Optional = -2,
        Failure = -1,
        PWError = 0,
        Success = 1,
    }//end enum
}//end namespace
