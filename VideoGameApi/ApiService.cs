using System.Text.Json;

namespace VideoGameApi
{
    public class ApiService : IApiService
    {
        private readonly ApiClient _apiClient;

        public ApiService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<ApiObject>> GetObjectsAsync()
        {
            var apiObjects = await _apiClient.GetObjectsAsync();

            // Process the data
            foreach (var obj in apiObjects)
            {
                if (obj.Data != null)
                {
                    if (obj.Data.ContainsKey("price") && obj.Data["price"] is JsonElement jsonPrice)
                    {
                        var price = jsonPrice.GetDecimal(); // Parse price
                        Console.WriteLine($"Price: {price}");
                    }

                    if (obj.Data.ContainsKey("color"))
                    {
                        var color = obj.Data["color"].ToString();
                        Console.WriteLine($"Color: {color}");
                    }
                }
            }
                return apiObjects;
        }
    }

}
