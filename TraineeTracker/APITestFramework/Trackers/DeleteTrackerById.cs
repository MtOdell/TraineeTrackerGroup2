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
    public class DeleteTrackerById : BaseService
    {
        public DeleteTrackerById()
        {
            CallManager = new CallManager();
            Resource = "/Trackers/Delete/";
            Method = Method.Delete;
        }
        public async Task MakeRequestAsync(string id)
        {
            ServiceResponse = await CallManager.MakeUserRequestAsync(Resource, id, Method);
            ResponseJson = JObject.Parse(ServiceResponse);
        }
    }
}
