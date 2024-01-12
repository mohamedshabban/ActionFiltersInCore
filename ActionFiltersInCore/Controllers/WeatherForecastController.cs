using ActionFiltersInCore.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ActionFiltersInCore.Controllers
{
    /// <summary>
    /// 2-Controller filter
    /// </summary>
    //[TypeFilter(typeof(LogActionFilter))]
    [ApiController]
    [Route("weather/api")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 1-Action filter
        /// This will cause the LogActionFilter to be executed before and after the Index method is called.
        /// </summary>
        /// <returns></returns>
        [LogActionFilter]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

}