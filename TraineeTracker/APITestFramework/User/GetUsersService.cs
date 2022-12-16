using APITestFramework.HttpManager;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APITestFramework.User
{
    public class GetUsersService : BaseService
    {
        public GetUsersService()
        {
            CallManager = new CallManager();
            Resource = "/UserDatas/";
            Method = Method.Get;
        }
        public async Task MakeRequestAsync()
        {
            ServiceResponse = await CallManager.MakeUserRequestAsync(Resource, Method);
            ResponseJson = JObject.Parse(ServiceResponse);
        }
    }
}
