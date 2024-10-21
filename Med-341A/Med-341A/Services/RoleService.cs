using Azure;
using Med_341A.datamodels;
using Med_341A.viewmodels;
using Newtonsoft.Json;
using System.Text;

namespace Med_341A.Services
{
    public class RoleService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        public string RouteAPI = "";

        private VMResponse response = new VMResponse();


        public RoleService(IConfiguration _configuration)
        {
            configuration = _configuration;
            RouteAPI = configuration["RouteAPI"];
        }

        public async Task<List<VRole>> GetAll()
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMRole/GetAll");
            List<VRole> data = JsonConvert.DeserializeObject<List<VRole>>(apiResponse)!;

            return data;
        }

        public async Task<VMResponse> Add(MRole dataForm)
        {
            //Proses convert dari objext ke string
            string json = JsonConvert.SerializeObject(dataForm);

            //proses ubah string ke json
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = await client.PostAsync(RouteAPI + "apiMRole/Add", content);

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

        public async Task<MRole> GetById(int id)
        {

            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMRole/GetById/{id}");
            MRole data = JsonConvert.DeserializeObject<MRole>(apiResponse);

            return data;
        }


        public async Task<VMResponse> Edit(MRole dataForm)
        {
            //Proses convert dari objext ke string
            string json = JsonConvert.SerializeObject(dataForm);

            //proses ubah string ke json
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = await client.PutAsync(RouteAPI + "apiMRole/Edit", content);

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

        public async Task<VMResponse> Delete(int id, int idUser)
        {
            var request = await client.DeleteAsync(RouteAPI + $"apiMRole/Delete/{id}/{idUser}");

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











    }
}
