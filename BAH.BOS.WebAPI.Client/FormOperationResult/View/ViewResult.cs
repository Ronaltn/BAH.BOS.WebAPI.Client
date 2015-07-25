using BAH.BOS.WebAPI.Client.FormOperationResult.FormOperation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.View
{
    [JsonObject]
    public class ViewResult<T> : ResultConvert<ViewResponseResult<T>>
    {

    }//end class
}//end namespace
