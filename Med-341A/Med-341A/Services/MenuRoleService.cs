using Med_341A.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Med_341A.Services
{
    public class MenuRoleService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        public string RouteAPI = "";

        private VMResponse response = new VMResponse();

        public MenuRoleService(IConfiguration _configuration)
        {
            configuration = _configuration;
            RouteAPI = configuration["RouteAPI"];
        }

        public async Task<VRole> GetMenuAccess_ById(int id)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMMenuRole/GetMenuAccess_ById/{id}");
            VRole data = JsonConvert.DeserializeObject<VRole>(apiResponse)!;

            return data;
        }

        public async Task<VMResponse> Edit_MenuAccess(VRole dataParam)
        {
            //Proses convert dari objext ke string
            string json = JsonConvert.SerializeObject(dataParam);

            //proses ubah string ke json
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = await client.PutAsync(RouteAPI + "apiMMenuRole/Edit_MenuAccess", content);

            if (request.IsSuccessStatusCode)
            {
                var apiResponse = await request.Content.ReadAsStringAsync();

                response = JsonConvert.DeserializeObject<VMResponse>(apiResponse);
            }
            else
            {
                response.Success = false;
                response.Message = $"{request.StatusCode} : {request.ReasonPhrase}";
            }

            return response;
        }

        public async Task<List<VMenuRole>> MenuAccess(int IdRole)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMMenuRole/MenuAccess/{IdRole}");
            List<VMenuRole> data = JsonConvert.DeserializeObject<List<VMenuRole>>(apiResponse);

            return data;
        }
    }
}
