using Med_341A.datamodels;
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
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMMedicalItem/GetAll/");
            List<VMedicalItem> data = JsonConvert.DeserializeObject<List<VMedicalItem>>(apiResponse)!;

            return data;
        }

        public async Task<List<MMedicalItemCategory>> GetCategory()
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMMedicalItem/GetCategory");
            List<MMedicalItemCategory> data = JsonConvert.DeserializeObject<List<MMedicalItemCategory>>(apiResponse)!;

            return data;
        }

        public async Task<List<MMedicalItemSegmentation>> GetSegmentation()
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMMedicalItem/GetSegmentation");
            List<MMedicalItemSegmentation> data = JsonConvert.DeserializeObject<List<MMedicalItemSegmentation>>(apiResponse)!;

            return data;
        }

        public async Task<string> GetCategoryName(int id)
        {
            string data = await client.GetStringAsync(RouteAPI + $"apiMMedicalItem/GetCategoryName/{id}");

            return data;
        }

        public async Task<string> GetSegmentationName(int id)
        {
            string data = await client.GetStringAsync(RouteAPI + $"apiMMedicalItem/GetSegmentationName/{id}");

            return data;
        }
    }
}
