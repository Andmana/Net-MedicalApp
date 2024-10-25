using Med_341A.viewmodels;
using Newtonsoft.Json;

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
    }
}
