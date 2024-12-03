using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace VideoGameApi.Controllers
{



    //[Route("api/[controller]")]


    [Route("api/MyApi")]
    [ApiController]
    public class MyApiController : ControllerBase
    {
        private readonly IApiService _apiService;

        public MyApiController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("objects")]
        public async Task<IActionResult> GetObjects()
        {
            var apiObjects = await _apiService.GetObjectsAsync();

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

            return Ok(apiObjects); // Return the original or modified list
        }
    }

}
