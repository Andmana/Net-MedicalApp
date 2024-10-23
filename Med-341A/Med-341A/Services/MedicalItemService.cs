using Med_341A.viewmodels;
using Newtonsoft.Json;

namespace Med_341A.Services
{
    public class MedicalItemService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        public string RouteAPI = "";

        private VMResponse response = new VMResponse();

        public MedicalItemService(IConfiguration _configuration)
        {
            configuration = _configuration;
            RouteAPI = configuration["RouteAPI"];
        }

        public async Task<List<VMedicalItem>> GetAll()
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMMedicalItem/GetAll");
            List<VMedicalItem> data = JsonConvert.DeserializeObject<List<VMedicalItem>>(apiResponse)!;

            return data;
        }
    }
}
