using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
         [HttpGet]
        public IActionResult Get() => Ok(new
        {
            Message = "API is running successfully!",
            Timestamp = DateTime.UtcNow
        });
    }
}
