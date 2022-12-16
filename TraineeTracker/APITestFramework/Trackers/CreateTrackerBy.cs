using APITestFramework.HttpManager;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTracker.Models;

namespace APITestFramework.Trackers
{
    public class CreateTrackerBy : BaseService
    {
        public CreateTrackerBy()
        {
            CallManager = new CallManager();
            Resource = "/Trackers/Create/";
            Method = Method.Post;
        }
        public async Task MakeRequestAsync(Tracker tracker)
        {
            ServiceResponse = await CallManager.MakeUserRequestAsync(Resource, tracker, Method);
            ResponseJson = JObject.Parse(ServiceResponse);
        }
    }
}
