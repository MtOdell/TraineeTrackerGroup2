using APITestFramework.HttpManager;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.User
{
    public class GetUserDetailsById : BaseService
    {
        public GetUserDetailsById()
        {
            CallManager = new CallManager();
            Resource = "/UserDatas/";
            Method = Method.Get;
        }
        public async Task MakeRequestAsync(string id)
        {
            ServiceResponse = await CallManager.MakeUserRequestAsync(Resource, id,  Method);
            var ResponseJson = JArray.Parse(ServiceResponse);
        }
    }
}
