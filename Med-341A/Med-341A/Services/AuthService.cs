using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
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
            routeApi = configuration["RouteAPI"];
        }

        public async Task<VMUser> CheckLogin(string email, string password)
        {
            string apiResponse = await client.GetStringAsync(routeApi + $"apiMAuth/CheckLogin/{email}/{password}");
            VMUser data = JsonConvert.DeserializeObject<VMUser>(apiResponse)!;

            return data;
        }

        public async Task<bool> CheckEmailIsRegistered(string email)
        {
            string apiResponse = await client.GetStringAsync($"{routeApi}apiMAuth/CheckEmailIsValid/{email}");

            bool data = JsonConvert.DeserializeObject<bool>(apiResponse);

            return data;
        }

        public async Task<bool> CheckPasswordIsValid(string email, string password)
        {
            string apiResponse = await client.GetStringAsync($"{routeApi}apiMAuth/CheckPasswordIsValid/{email}/{password}");

            bool data = JsonConvert.DeserializeObject<bool>(apiResponse);

            return data;
        }
    }
}