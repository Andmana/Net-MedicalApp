using System.Text;
using Med_341A.viewmodels;
using Newtonsoft.Json;

namespace Med_341A.Services
{
    public class AuthService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        public string routeApi = "";

        public AuthService(IConfiguration _configuration)
        {
            configuration = _configuration;
            routeApi = configuration["RouteApi"] ?? throw new ArgumentNullException(nameof(routeApi), "RouteApi is missing in configuration");
        }

        public async Task<VMUser> CheckLogin(string email, string password)
        {
            string apiResponse = await client.GetStringAsync(routeApi + $"apiMAuth/CheckLogin/{email}/{password}");
            VMUser data = JsonConvert.DeserializeObject<VMUser>(apiResponse)!;

            return data;
        }

        public async Task<bool> CheckEmailIsRegistered(string email)
        {
            string apiResponse = await client.GetStringAsync($"{routeApi}apiMAuth/CheckEmailIsRegistered/{email}");

            bool data = JsonConvert.DeserializeObject<bool>(apiResponse);

            return data;
        }

        public async Task<bool> CheckPasswordIsValid(string email, string password)
        {
            string apiResponse = await client.GetStringAsync($"{routeApi}apiMAuth/CheckPasswordIsValid/{email}/{password}");

            bool data = JsonConvert.DeserializeObject<bool>(apiResponse);

            return data;
        }

        public async Task<VMUser> CheckLoginV2(string email, string password)
        {
            string json = JsonConvert.SerializeObject(new { Email = email, Password = password });

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{routeApi}apiMAuth/CheckLoginV2", content);

            string apiResponse = await request.Content.ReadAsStringAsync();

            VMUser data = JsonConvert.DeserializeObject<VMUser>(apiResponse)!;

            return data;
        }

        public async Task<bool> CheckPasswordIsValidV2(string email, string password)
        {
            string json = JsonConvert.SerializeObject(new { Email = email, Password = password });

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{routeApi}apiMAuth/CheckPasswordIsValidV2", content);

            string apiResponse = await request.Content.ReadAsStringAsync();

            bool data = JsonConvert.DeserializeObject<bool>(apiResponse);

            return data;
        }
    }
}