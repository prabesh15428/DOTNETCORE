using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Upload
    {

        
        public void UploadFile(List<IFormFile> postedFiles, IWebHostEnvironment webHostEnvironment) {

            
            string path = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                if (postedFile.FileName.EndsWith(".png") || postedFile.FileName.EndsWith(".jpg") || postedFile.FileName.EndsWith(".pdf") || postedFile.FileName.EndsWith(".pdf"))
                {
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        // ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);


                        Image i = new Image();
                        i.ImageUrl = "/upload/" + postedFile.FileName;
                        new UserDb().AddUrl(i);
                    }
                }
                
            }
        }
       

        
    }
}
