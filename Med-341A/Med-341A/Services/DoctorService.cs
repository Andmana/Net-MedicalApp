using Med_341A.viewmodels;
using Newtonsoft.Json;

namespace Med_341A.Services
{
    public class DoctorService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        public string RouteAPI = "";

        public DoctorService(IConfiguration _configuration)
        {
            configuration = _configuration;
            RouteAPI = configuration["RouteAPI"];
        }

        public async Task<List<VMDoctor>> GetAll()
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiDoctor/GetAll");
            List<VMDoctor> data = JsonConvert.DeserializeObject<List<VMDoctor>>(apiResponse)!;

            return data;
        }
    }
}