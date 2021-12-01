using FileHandling.Models;
using FileHandling.ModelView;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandling.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
       

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] ItemModelView objItem)
        {
            new ImportExcel().upload_file(objItem.itemss, _webHostEnvironment);
            string path = "wwwroot/upload/" + objItem.itemss.FileName;
            new ImportExcel().import(path);
            return RedirectToAction("Index");
        }
        public IActionResult Export()
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

                    worksheet.Cells["A1"].Value = "Name";
                    worksheet.Cells["B1"].Value = "Quantity";
                    worksheet.Cells["C1"].Value = "Amount";
                    worksheet.Cells["D1"].Value = "Discount";
                    worksheet.Cells["E1"].Value = "Rate";

                    row = 2;
                    foreach (var item in objItems)
                    {
                        worksheet.Cells[row, 1].Value = item.item_name;
                        worksheet.Cells[row, 2].Value = item.item_quantity;
                        worksheet.Cells[row, 3].Value = item.item_amount;
                        worksheet.Cells[row, 4].Value = item.item_discount;
                        worksheet.Cells[row, 5].Value = item.item_rate;
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
