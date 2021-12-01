using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Net;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    } 
}  
   
