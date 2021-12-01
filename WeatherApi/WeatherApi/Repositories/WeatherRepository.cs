using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.OpenWeatherMapModels;

namespace WeatherApi.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        WeatherResponse IWeatherRepository.GetWeather(string weather)
        {
           
            // Connection String
            var client = new RestClient($"http://api.weatherapi.com/v1/current.json?key=e79be1ff301249c4bf562139211911&q=London&aqi=no");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

               
                return content.ToObject<WeatherResponse>();
            }

            return null;
        }
    }
}
