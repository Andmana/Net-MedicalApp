using Med_341A.viewmodels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Med_341A.Services
{
    public class UserProfileService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        private string RouteAPI = "";
        private VMResponse respon = new VMResponse();

        public UserProfileService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.RouteAPI = this.configuration["RouteAPI"]!;
        }

        //Mendapatkan data akun dan data biodata berdasarkan id user
        public async Task<VMUser> GetDataUser(int id)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiUserProfile/GetDataUser/{id}");
            VMUser data = JsonConvert.DeserializeObject<VMUser>(apiResponse)!;
            return data;
        }

        public async Task<VMResponse> UbahPribadi(VMUser dataParam)
        {
            string json = JsonConvert.SerializeObject(dataParam);
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var request = await client.PutAsync(RouteAPI + "apiUserProfile/UbahPribadi", content);

            if (request.IsSuccessStatusCode)
            {
                var apiRespon = await request.Content.ReadAsStringAsync();
                respon = JsonConvert.DeserializeObject<VMResponse>(apiRespon)!;
            }
            else
            {
                respon.Success = false;
                respon.Message = $"{request.StatusCode} : {request.ReasonPhrase}";
            }

            return respon;
        }

        public async Task<bool> CheckPassword(string email, string password)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMAuth/CheckPasswordIsValid/{email}/{password}");
            bool data = JsonConvert.DeserializeObject<bool>(apiResponse);
            return data;
        }
    }
}
