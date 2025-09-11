using DotNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // controller path
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecast _weatherForecast;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecast weatherForecast)
        {
            _logger = logger;
            _weatherForecast = weatherForecast;
        }

        [HttpGet("GetWeatherForecast")] // Action Name 
        public IActionResult GetWeatherForecast()
        {

            _logger.LogWarning("Hello World !");
            try
            {
                var data = _weatherForecast.GetWeatherForecast();
                if (data is not null)
                {
                    return Ok(data);
                }
                else
                { 
                    return NotFound("No data Found");
                }
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

            
        }

       


    }
}
