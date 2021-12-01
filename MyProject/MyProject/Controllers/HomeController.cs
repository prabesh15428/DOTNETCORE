using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
   
    public class HomeController : Controller
    {
        private IWebHostEnvironment Environment;
        public HomeController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<User> objuser = new UserDb().GetAll().ToList();
            return View(objuser);
        }

        [HttpPost]
        public ActionResult Index(List<IFormFile> postedFiles)
        {
            new Upload().UploadFile(postedFiles, Environment);              
            return View();
        }
       
        public ActionResult Details()
        {
            return View();
        }
       
      [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("create")]
        public ActionResult Create_Post(User u)
        {
            if (ModelState.IsValid)
            {
                new UserDb().createUser(u);
                return RedirectToAction("List");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var a = new UserDb().GetAll().Where(x => x._id == id).First();
            return View(a);
        }
        [HttpPost]
        [ActionName("edit")]
        public ActionResult Edit_Post(User u)
        {
            new UserDb().editUser(u);
            return RedirectToAction("List");
           /* return View();*/
        }
        public ActionResult List()
        {
            var userList = new UserDb().GetAll();
            return View(userList);
        }



        public ActionResult Sample()
        {
            
            return View();
        }
        
        public ActionResult Login(User us)
        {
            new UserDb().LoginCheck(us);
            if (ModelState.IsValid)
              {
                  
                  return RedirectToAction("Sample");                
              }
              else
           
                
                return View();
        }
    }
}

