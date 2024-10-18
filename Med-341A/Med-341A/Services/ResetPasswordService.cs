using Med_341A.viewmodels;
using Newtonsoft.Json;
using System.Text;

namespace Med_341A.Services
{
    public class ResetPasswordService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly IConfiguration configuration;
        private readonly string RouteAPI = "";

        public ResetPasswordService(IConfiguration _configuration)
        {
            this.configuration = _configuration;
            this.RouteAPI = configuration["RouteApi"];

        }
        public async Task<VMResponse> RequestOTP(VResetPassword userRequest)
        {
            var json = JsonConvert.SerializeObject(userRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{RouteAPI}apiTResetPassword/RequestOTP", content);

            var apiResponse = await request.Content.ReadAsStringAsync();

            VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

            return data;
        }

        public async Task<VMResponse> VerifyOTP(VResetPassword dataForm)
        {
            var json = JsonConvert.SerializeObject(dataForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{RouteAPI}apiTResetPassword/VerifyOTP", content);

            var apiResponse = await request.Content.ReadAsStringAsync();

            VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

            return data;
        }

        public async Task<VMResponse> SavePassword(VResetPassword dataForm)
        {
            var json = JsonConvert.SerializeObject(dataForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{RouteAPI}apiTResetPassword/SaveNewPassword", content);

            var apiResponse = await request.Content.ReadAsStringAsync();

            VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

            return data;
        }
    }


}
