using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherAsync(string cityName);
    }
}
