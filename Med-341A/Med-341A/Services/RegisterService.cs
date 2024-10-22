using System.Text;
using Med_341A.viewmodels;
using Newtonsoft.Json;

namespace Med_341A.Services;

public class RegisterService
{
    private readonly HttpClient client = new HttpClient();
    private readonly IConfiguration configuration;
    private readonly string routeApi;


    public RegisterService(IConfiguration _configuration)
    {
        this.configuration = _configuration;
        this.routeApi = configuration["RouteApi"] ?? throw new ArgumentNullException(nameof(routeApi), "RouteApi is missing in configuration");
    }

    public async Task<VMResponse> RequestOTP(string email)
    {
        var userRequest = new { Email = email, usedFor = "Register" };

        var json = JsonConvert.SerializeObject(userRequest);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = await client.PostAsync($"{routeApi}apiMAuth/RequestOTP", content);

        var apiResponse = await request.Content.ReadAsStringAsync();

        VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

        return data;
    }

    public async Task<VMResponse> VerifyOTP(string email, string otp)
    {
        var userRequest = new { Email = email, OTP = otp, usedFor = "Register" };
        var json = JsonConvert.SerializeObject(userRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = await client.PostAsync($"{routeApi}apiMAuth/VerifyOTP", content);

        var apiResponse = await request.Content.ReadAsStringAsync();

        VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

        return data;
    }

    public async Task<VMResponse> RegisterNewUser(VMUser userData)
    {
        var json = JsonConvert.SerializeObject(userData);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var request = await client.PostAsync($"{routeApi}apiMAuth/RegisterNewUser", content);

        var apiResponse = await request.Content.ReadAsStringAsync();

        VMResponse data = JsonConvert.DeserializeObject<VMResponse>(apiResponse)!;

        return data;

    }
}
