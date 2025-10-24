//using System;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//public class ApiClient
//{
//    private readonly HttpClient _httpClient;

//    public ApiClient(HttpClient httpClient)
//    {
//        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
//    }

//    public async Task<string> PostDataAsync<T>(string endpoint, T data) 
//    {
//        try
//        {
//            string jsonContent = System.Text.Json.JsonSerializer.Serialize(data);
//            using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

//            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);

//            response.EnsureSuccessStatusCode();

//            string responseBody = await response.Content.ReadAsStringAsync();
//            return responseBody;
//        }
//        catch (HttpRequestException ex)
//        {
//            Console.WriteLine($"HTTP Request failed: {ex.Message}");
//            throw;
//        }
//    }
//}
