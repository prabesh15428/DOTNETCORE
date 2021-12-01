using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandling.Models
{
    public class ImportExcel
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
                            
                            item_name = reader.GetValue(0).ToString(),
                            item_quantity = (Decimal)reader.GetDouble(1),
                            item_amount = (Decimal)reader.GetDouble(2),

                            item_discount = (Decimal)reader.GetDouble(3),
                            item_rate = (Decimal)reader.GetDouble(4)
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
