using System.Text.Json;

namespace VideoGameApi
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ApiObject>> GetObjectsAsync()
        {
            var response = await _httpClient.GetAsync("objects");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ApiObject>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

    }

}
