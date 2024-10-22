using Med_341A.viewmodels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Net.Http.Headers;
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

        public async Task<VMUploadGambar> GetDataGambar(int id)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiUserProfile/GetDataGambar/{id}");
            VMUploadGambar data = JsonConvert.DeserializeObject<VMUploadGambar>(apiResponse)!;
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
            string json = JsonConvert.SerializeObject(new { Email = email, Password = password });

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync(RouteAPI + "apiMAuth/CheckPasswordIsValidV2", content);

            string apiResponse = await request.Content.ReadAsStringAsync();

            bool data = JsonConvert.DeserializeObject<bool>(apiResponse);

            return data;
        }
        public async Task<VMResponse> UbahGambar(VMUploadGambar dataParam)
        {
            var content = new MultipartFormDataContent();

            // Add the file to the form content
            if (dataParam.ImageFile != null)
            {
                var fileContent = new StreamContent(dataParam.ImageFile.OpenReadStream());
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(dataParam.ImageFile.ContentType);
                content.Add(fileContent, "File", dataParam.ImageFile.FileName);
            }

            // Add other fields as form data
            content.Add(new StringContent(dataParam.BiodataId.ToString()!), "BiodataId");
            content.Add(new StringContent(dataParam.Id.ToString()), "Id");
            content.Add(new StringContent(dataParam.ImagePath ?? ""), "ImagePath");

            // Make the API request
            var request = await client.PutAsync(RouteAPI + "apiUserProfile/UbahGambar", content);

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
        public async Task<VMResponse> UpdatePassword(VMUser userData)
        {
            var json = JsonConvert.SerializeObject(userData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync(RouteAPI + "apiUserProfile/UpdatePassword", content);

            var apiResponse = await request.Content.ReadAsStringAsync();

            VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

            return data;
        }
        public async Task<bool> CheckEmail(string email)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiUserProfile/CheckEmailIsExist/{email}");
            bool data = JsonConvert.DeserializeObject<bool>(apiResponse);
            return data;
        }
        public async Task<VMResponse> RequestOTPEmailBaru(string email, int id)
        {
            var userRequest = new { Email = email, usedFor = "Update_Email", UserId = id};

            var json = JsonConvert.SerializeObject(userRequest);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync(RouteAPI + "apiUserProfile/RequestOTPEmailBaru", content);

            var apiResponse = await request.Content.ReadAsStringAsync();

            VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

            return data;
        }
        public async Task<VMResponse> VerifikasiOTP(string email, string otp, int id)
        {
            var userRequest = new { Email = email, usedFor = "Update_Email", UserId = id, OTP = otp };
            var json = JsonConvert.SerializeObject(userRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync(RouteAPI + "apiUserProfile/VerifikasiOTP", content);

            var apiResponse = await request.Content.ReadAsStringAsync();

            VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

            return data;
        }
    }
}
