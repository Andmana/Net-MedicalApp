using Med_341A.datamodels;
using Med_341A.viewmodels;
using Newtonsoft.Json;

namespace Med_341A.Services;

public class FindDoctorService
{

    private static readonly HttpClient client = new HttpClient();
    private IConfiguration configuration;
    private readonly VMResponse response = new();
    public string routeApi = "";

    public FindDoctorService(IConfiguration _configuration)
    {
        configuration = _configuration;
        routeApi = configuration["RouteApi"] ?? throw new ArgumentNullException(nameof(routeApi), "RouteApi is missing in configuration");
    }

    public async Task<List<MLocation>> GetAllCity()
    {
        List<MLocation> data = new();

        try
        {
            // Making the HTTP GET request
            string apiResponse = await client.GetStringAsync($"{routeApi}apiFindDoctor/GetAllCity");

            // Deserialize the JSON response
            data = JsonConvert.DeserializeObject<List<MLocation>>(apiResponse) ?? new List<MLocation>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Request error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Deserialization error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return data;
    }

    public async Task<List<MSpecialization>> GetAllSpecialization()
    {
        List<MSpecialization> data = new();

        try
        {
            // Making the HTTP GET request
            string apiResponse = await client.GetStringAsync($"{routeApi}apiFindDoctor/GetAllSpecialization");

            // Deserialize the JSON response
            data = JsonConvert.DeserializeObject<List<MSpecialization>>(apiResponse) ?? new List<MSpecialization>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Request error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Deserialization error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return data;
    }

    public async Task<List<VMDoctorTreatment>> GetAllDcotorTreatment()
    {
        List<VMDoctorTreatment> data = new();

        try
        {
            // Making the HTTP GET request
            string apiResponse = await client.GetStringAsync($"{routeApi}apiFindDoctor/GetAllDoctorTreatment");

            // Deserialize the JSON response
            data = JsonConvert.DeserializeObject<List<VMDoctorTreatment>>(apiResponse) ?? new List<VMDoctorTreatment>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Request error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Deserialization error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return data;
    }

    public async Task<List<VMSearchDoctor>> GetAllSearchDoctor()
    {
        List<VMSearchDoctor> data = new();

        try
        {
            // Making the HTTP GET request
            string apiResponse = await client.GetStringAsync($"{routeApi}apiFindDoctor/GetAllDoctor");

            // Deserialize the JSON response
            data = JsonConvert.DeserializeObject<List<VMSearchDoctor>>(apiResponse) ?? new List<VMSearchDoctor>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Request error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Deserialization error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return data;
    }

}
