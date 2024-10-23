using Med_341A.viewmodels;
using Newtonsoft.Json;

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
    }
}
