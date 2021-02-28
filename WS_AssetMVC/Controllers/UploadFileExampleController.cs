using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WS_AssetMVC.Controllers
{
    public class UploadFileExampleController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadFileExampleController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UploadFileExamplePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFilesAjax(IEnumerable<IFormFile> files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwPath = this._webHostEnvironment.WebRootPath;
                    string contentPath = this._webHostEnvironment.ContentRootPath;
                    string path = Path.Combine(this._webHostEnvironment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    foreach (IFormFile postedFile in files)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                       // var filepath = Path.Combine(path, fileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                        }
                    }

                    return Json(new { status = "success", message = "success" });
                }
                else
                {
                    var list = new List<string>();
                    foreach (var modelStateVal in ViewData.ModelState.Values)
                    {
                        list.AddRange(modelStateVal.Errors.Select(error => error.ErrorMessage));
                    }
                    return Json(new { status = "error", errors = list });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
