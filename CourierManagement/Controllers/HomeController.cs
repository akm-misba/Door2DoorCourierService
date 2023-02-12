
using CourierManagement.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment Environment;

        public HomeController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult Index()
        {
           
            string[] filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "Files/"));

            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
           
            string path = Path.Combine(this.Environment.WebRootPath, "Files/") + fileName;

      
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }
        
    }
}
