using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.AuthOperationResult
{
    /// <summary>
    /// 登录结果枚举。
    /// </summary>
    public enum LoginResultType
    {
        Success = 1,
        PWError = 0,
        Failure = -1,
        PWInvalid_Optional = -2,
        PWInvalid_Required = -3,
        Wanning = -4,
        DealWithForm = -5,
        Activation = -7
    }//end enum
}//end namespace
