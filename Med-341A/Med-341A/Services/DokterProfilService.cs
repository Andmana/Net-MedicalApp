using Med_341A.viewmodels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Med_341A.Services
{
    public class DokterProfilService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        private string RouteAPI = "";
        private VMResponse respon = new VMResponse();

        public DokterProfilService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.RouteAPI = this.configuration["RouteAPI"]!;
        }

        public async Task<VMDoctor> GetDataDokter (int id)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiDokterProfile/GetDataDokter/{id}");
            VMDoctor data = JsonConvert.DeserializeObject<VMDoctor>(apiResponse)!;
            return data;
        }

        public async Task<VMUploadGambar> GetDataGambar(int id)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiUserProfile/GetDataGambar/{id}");
            VMUploadGambar data = JsonConvert.DeserializeObject<VMUploadGambar>(apiResponse)!;
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
    }
}
