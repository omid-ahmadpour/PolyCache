using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                         IWeatherService weatherService)
        {
            _logger = logger;
            this.weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("cache")]
        public async Task<IEnumerable<WeatherForecast>> GetFromCache()
        {
            var result = await weatherService.GetWeatherAsync();
            return result;
        }
    }
}
