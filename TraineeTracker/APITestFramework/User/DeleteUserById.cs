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
    public class DeleteUserById : BaseService
    {
        public DeleteUserById()
        {
            CallManager = new CallManager();
            Resource = "/UserDatas/Delete/";
            Method = Method.Delete;
        }
        public async Task MakeRequestAsync(string id)
        {
            ServiceResponse = await CallManager.MakeUserRequestAsync(Resource, id, Method);
            ResponseJson = JObject.Parse(ServiceResponse);
        }
    }
}
