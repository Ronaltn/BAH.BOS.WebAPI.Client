using BAH.BOS.WebAPI.Client.FormOperationResult;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAH.BOS.WebAPI.Client.FormOperationResult.Save
{
    [JsonObject]
    public class SaveResult<TReturn> : ResultConverter<SaveFormResult<TReturn>>
    {

    }//end class

    [JsonObject]
    public class SaveResult : ResultConverter<SaveFormResult<object>>
    {

    }//end class
}//end namespace
