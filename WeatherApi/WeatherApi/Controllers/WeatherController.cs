using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Models;
using WeatherApi.OpenWeatherMapModels;
using WeatherApi.Repositories;

namespace WeatherApi.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;

        public IActionResult Search()
        {
            var viewModel = new Search();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Search(Search model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Weather", "WeatherApi", new { Weather = model.CityName });
            }
            return View(model);
        }

        public IActionResult Weather(string weather)
        {
            WeatherResponse weatherResponse = _weatherRepository.GetWeather(weather);
            Weather viewModel = new Weather();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity.ToString();   
                viewModel.Pressure = weatherResponse.Main.Pressure.ToString();
                viewModel.Temp = weatherResponse.Main.Temp.ToString();
                viewModel.Weater = weatherResponse.Weathers[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed.ToString();
            }

           
            return View(viewModel);
        }

        /*   public WeatherController(IWeatherRepository weatherApiRepo)
           {
               _weatherRepository = weatherApiRepo;
           }*/
      
    }
}
