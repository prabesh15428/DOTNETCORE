using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelFileHandling.Models
{
    public class FileImportExcel
    {
       
        public Task upload_file(IFormFile file, IWebHostEnvironment webHostEnvironment)
        {
            string upload = Path.Combine(webHostEnvironment.WebRootPath, "upload");
            //creates a directory if it doesnt exist
            if (!Directory.Exists(upload))
            {
                Directory.CreateDirectory(upload);
            }
            if (file.Length > 0)
            {
                string filepath = Path.Combine(upload, file.FileName); 
                using (Stream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
            }
            return Task.CompletedTask;
        }
        public void import(string path)
        {
            List<Item> items = new List<Item>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    reader.Read();
                    while (reader.Read())
                    {
                        items.Add(new Item()
                        {
                            ItemName = reader.GetValue(0).ToString(),
                            ItemQuantity = (Decimal)reader.GetDouble(1),
                            ItemRate = (Decimal)reader.GetDouble(2),

                            Discount = (Decimal)reader.GetDouble(3),
                            Amount = (Decimal)reader.GetDouble(4)
                        });
                    }
                }
            }
            foreach (var item in items)
            {
                new ItemDb().AddItem(item);
            }
        }
    }   
}
