using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.OpenWeatherMapModels;

namespace WeatherApi.Repositories
{
    interface IWeatherRepository
    {
        WeatherResponse GetWeather(string weather);
    }
}
