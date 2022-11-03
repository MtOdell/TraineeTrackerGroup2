using System.Data;
using TraineeTracker.Security.Authorization;

namespace TraineeTracker.Security.Authentication
{
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;

        public InMemoryGetApiKeyQuery()
        {
            var existingApiKeys = new List<ApiKey>
            {
                new ApiKey(1, "Trainee", "C5BFF7F0-B4DF-475E-A331-F737424F013C", new DateTime(2022, 01, 01),
                    new List<string>
                    {
                        Roles.Trainee,
                    }),
                new ApiKey(2, "Trainer", "5908D47C-85D3-4024-8C2B-6EC9464398AD", new DateTime(2022, 01, 01),
                    new List<string>
                    {
                        Roles.Trainer,
                    }),
                new ApiKey(3, "Admin", "06795D9D-A770-44B9-9B27-03C6ABDB1BAE", new DateTime(2022, 01, 01),
                    new List<string>
                    {
                        Roles.Admin
                    })
            };

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
