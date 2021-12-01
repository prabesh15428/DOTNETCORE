using ExcelFileHandling.Models;
using ExcelFileHandling.ModelView;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace ExcelFileHandling.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
   

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
          
        }
        [HttpGet]
        public IActionResult Index()
        {
            var items = new ItemDb().GetAll();

            return View(items);


        }
        [HttpPost]
        public ActionResult Index([FromForm]ItemModelView objItem)
        {
            new FileImportExcel().upload_file(objItem.itemss, _webHostEnvironment);
            string path = "wwwroot/upload/" + objItem.itemss.FileName;
            new FileImportExcel().import(path);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index1()
        {
                        return View();


        }
        [HttpPost]
        public IActionResult Index1([FromForm] ItemModelView objItem)
        {
            new FileImportExcel().upload_file(objItem.itemss, _webHostEnvironment);
            string path = "wwwroot/upload/" + objItem.itemss.FileName;
            new FileImportExcel().import(path);
            return RedirectToAction("Index");
            
        }
       
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public ActionResult ItemAdd(Item it)
        {
            if (ModelState.IsValid)
            {
                new ItemDb().AddItem(it);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        
        public IActionResult DownloadExcel()
        {
            List<Item> objItems = new ItemDb().GetAll();
            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("items");
                var Customerstyle = xlPackage.Workbook.Styles.CreateNamedStyle("customerStyle");
                Customerstyle.Style.Font.UnderLine = true;
                Customerstyle.Style.Font.Color.SetColor(Color.Black);

                var startRow = 5;
                var row = startRow;

                worksheet.Cells["A1"].Value = "ItemName";
                worksheet.Cells["B1"].Value = "ItemRate";
                worksheet.Cells["C1"].Value = "ItemQuantity";
                worksheet.Cells["D1"].Value = "Discount";
                worksheet.Cells["E1"].Value = "Amount";

                row = 2;
                foreach (var item in objItems)
                {
                    worksheet.Cells[row, 1].Value = item.ItemName;
                    worksheet.Cells[row, 2].Value = item.ItemRate;
                    worksheet.Cells[row, 3].Value = item.ItemQuantity;
                    worksheet.Cells[row, 4].Value = item.Discount;
                    worksheet.Cells[row, 5].Value = item.Amount;
                    row++;
                }

                xlPackage.Workbook.Properties.Title = "Item";

                xlPackage.Save();


            }

            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "item.xlsx");



        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
