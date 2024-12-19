using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models;

namespace WebAppMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public class FileUploadModel
        {
            public IFormFile File { get; set; }
            public string UploadFileType { get; set; }
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile fileToUpload, string UploadFileType)
        {
            if (fileToUpload != null && fileToUpload.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileToUpload.FileName);

                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileToUpload.CopyToAsync(stream);
                }

                return Ok(new { message = $"{UploadFileType} File uploaded to {filePath}" });
            }
            else
            {
                return BadRequest("No file uploaded.");
            }
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
