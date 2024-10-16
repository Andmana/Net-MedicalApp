using Med_341A.datamodels;
using Med_341A.viewmodels;
using Newtonsoft.Json;

namespace Med_341A.Services
{
    public class MHakAksesService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        public string RouteAPI = "";

        public MHakAksesService(IConfiguration _configuration)
        {
            configuration = _configuration;
            RouteAPI = configuration["RouteAPI"];
        }

        public async Task<List<MRole>> GetAll()
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiMRole/GetAll");
            List<MRole> data = JsonConvert.DeserializeObject<List<MRole>>(apiResponse)!;

            return data;
        }
    }
}
