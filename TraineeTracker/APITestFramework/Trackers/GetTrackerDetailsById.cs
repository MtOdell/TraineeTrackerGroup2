using APITestFramework.HttpManager;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestFramework.Trackers
{
    public class GetTrackerDetailsById : BaseService
    {
        public GetTrackerDetailsById()
        {
            CallManager = new CallManager();
            Resource = "/Trackers/Details/";
            Method = Method.Get;
        }
        public async Task MakeRequestAsync(string id)
        {
            ServiceResponse = await CallManager.MakeUserRequestAsync(Resource, id, Method);
            ResponseJson = JObject.Parse(ServiceResponse);
        }
    }
}
