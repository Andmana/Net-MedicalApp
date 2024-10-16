using Med_341A.viewmodels;
using Newtonsoft.Json;
using System.Text.Json;

namespace Med_341A.Services
{
    public class UserProfileService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        private string RouteAPI = "";
        private VMResponse respon = new VMResponse();

        public UserProfileService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.RouteAPI = this.configuration["RouteAPI"];
        }

        //Mendapatkan data akun dan data biodata berdasarkan id user
        public async Task<VMUser> GetDataUser(int id)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"apiUserProfile/GetDataUser/{id}");
            VMUser data = JsonConvert.DeserializeObject<VMUser>(apiResponse)!;
            return data;
        }
    }
}
