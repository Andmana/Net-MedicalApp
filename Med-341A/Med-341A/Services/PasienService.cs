using Med_341A.datamodels;
using Med_341A.viewmodels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Text;

namespace Med_341A.Services
{
    public class PasienService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        private string RouteAPI = "";
        private VMResponse respon = new VMResponse();
        public PasienService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.RouteAPI = this.configuration["RouteAPI"]!;
        }

        //Get Semnua data berdasarkan id user kemudian di ambil id biodata untuk get semua data di tabel relasi customer
        public async Task<List<VMPasien>> GetAllData(int id)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiPasien/GetAllData/{id}");
            List<VMPasien> data = JsonConvert.DeserializeObject<List<VMPasien>>(apiResponse);
            return data;
        }

        public async Task<List<MCustomerRelation>> GetAllRelasi()
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + "apiPasien/GetAllRelasi");
            List<MCustomerRelation> data = JsonConvert.DeserializeObject<List<MCustomerRelation>>(apiResponse);
            return data;
        }
        public async Task<List<MBloodGroup>> GetAllGoldar()
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + "apiPasien/GetAllGoldar");
            List<MBloodGroup> data = JsonConvert.DeserializeObject<List<MBloodGroup>>(apiResponse);
            return data;
        }
        public async Task<VMResponse> TambahPasien(VMPasien dataParam)
        {
            string json = JsonConvert.SerializeObject(dataParam);
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var request = await client.PostAsync(RouteAPI + "apiPasien/Simpan", content);
            if (request.IsSuccessStatusCode)
            {
                var apiRespon = await request.Content.ReadAsStringAsync();
                respon = JsonConvert.DeserializeObject<VMResponse>(apiRespon);
            }
            else
            {
                respon.Success = false;
                respon.Message = $"{request.StatusCode} : {request.ReasonPhrase}";
            }

            return respon;
        }
        public async Task<VMPasien> GetPasienByIdCustomer(int id)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiPasien/GetPasienByIdCustomer/{id}");
            VMPasien data = JsonConvert.DeserializeObject<VMPasien>(apiResponse);
            return data;
        }

        public async Task<VMResponse> EditPasien(VMPasien dataForm)
        {
            string json = JsonConvert.SerializeObject(dataForm);
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var request = await client.PutAsync(RouteAPI + "apiPasien/EditPasien", content);
            if (request.IsSuccessStatusCode)
            {
                var apiRespon = await request.Content.ReadAsStringAsync();
                respon = JsonConvert.DeserializeObject<VMResponse>(apiRespon);
            }
            else
            {
                respon.Success = false;
                respon.Message = $"{request.StatusCode} : {request.ReasonPhrase}";
            }

            return respon;
        }

        public async Task<VMResponse> DeletePasien(int idUser, int idCustomer)
        {
            var request = await client.DeleteAsync(RouteAPI + $"apiPasien/DeletePasien/{idUser}/{idCustomer}");
            if (request.IsSuccessStatusCode)
            {
                var apiRespon = await request.Content.ReadAsStringAsync();
                respon = JsonConvert.DeserializeObject<VMResponse>(apiRespon);
            }
            else
            {
                respon.Success = false;
                respon.Message = $"{request.StatusCode} : {request.ReasonPhrase}";
            }
            return respon;
        }

        public async Task<VMResponse> MultipleDelete(int idUser, List<int> listId)
        {
            string json = JsonConvert.SerializeObject(new { IdUser = idUser, ListId = listId });

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PutAsync(RouteAPI + "apiPasien/MultipleDelete", content);

            if (request.IsSuccessStatusCode)
            {
                var apiRespon = await request.Content.ReadAsStringAsync();
                respon = JsonConvert.DeserializeObject<VMResponse>(apiRespon);
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
