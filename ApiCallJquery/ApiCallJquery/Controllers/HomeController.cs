using ApiCallJquery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCallJquery.Controllers
{
    public class HomeController : Controller
    {
       [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddData( string location, string country, string lat, string lon)
        {
            
            ApiCall objdet = new ApiCall()
            {
                
                location = location,
                country = country,
                lat = lat,
                lon = lon,
            };
            new ApiCallDb().apiData(objdet);
            return RedirectToAction("Index");

            
        }


        [HttpGet]
        public IActionResult SaveData()
        {
            var objDeta = new ApiCallDb().getdetail().ToList();
            return View(objDeta);

        }


    }
}

    