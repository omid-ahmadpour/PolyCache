using PolyCache.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class WeatherService : IWeatherService
    {
        private const string CachePrefix = "weather_";
        private const int CacheExpiryTime = 2; //minitues

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IStaticCacheManager staticCacheManager;

        public WeatherService(IStaticCacheManager staticCacheManager)
        {
            this.staticCacheManager = staticCacheManager ?? throw new ArgumentNullException(nameof(staticCacheManager));
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherAsync(string cityName)
        {
            var result = await staticCacheManager.GetWithExpireTimeAsync(
                new CacheKey(CachePrefix + cityName),
                CacheExpiryTime,
                async () => await GetWeather());

            return result;

            async Task<IEnumerable<WeatherForecast>> GetWeather()
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
        }
    }
}
