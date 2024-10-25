using Med_341A.datamodels;
using Med_341A.viewmodels;
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
    }
}
