using APITestFramework.HttpManager;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APITestFramework.Trackers
{
    public class GetTrackersById : BaseService
    {
        public GetTrackersById()
        {
            CallManager = new CallManager();
            Resource = "/Trackers/Index/";
            Method = Method.Get;
        }
        public async Task MakeRequestAsync(string id)
        {
            ServiceResponse = await CallManager.MakeUserRequestAsync(Resource, id, Method);
            ResponseJson = JObject.Parse(ServiceResponse);
        }
    }
}
