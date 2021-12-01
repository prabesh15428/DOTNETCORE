using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    public class Weather
    {
        [Display(Name = "City:")]
        public string Name { get; set; } 

        [Display(Name = "Temperature")]
        public string Temp { get; set; }

        [Display(Name = "Humidity")]
        public string Humidity { get; set; }

        [Display(Name = "Pressure")]
        public string Pressure { get; set; } 

        [Display(Name = "Wind")]
        public string Wind { get; set; } 

        [Display(Name = "Weather Condition")]
        public string Weater { get; set; }
    }
}
