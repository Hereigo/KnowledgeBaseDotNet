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

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile fileToUpload, string uploadFileType)
        {
            if (fileToUpload == null || fileToUpload.Length < 1 || string.IsNullOrWhiteSpace(uploadFileType))
            {
                return BadRequest("No file uploaded or file-type not selected.");
            }
            else
            {
                try
                {
                    string FileNameOnServer = Path.GetTempPath();
                    FileNameOnServer += fileToUpload.FileName;

                    long FileContentLength = fileToUpload.Length; // bytes
                    string FileContentType = fileToUpload.ContentType;

                    using var stream = System.IO.File.Create(FileNameOnServer);
                    fileToUpload.CopyTo(stream);

                    // TODO
                    // upload into DB here ..........................

                    // FileNameOnServer

                    return Ok(new { message = $"File uploaded to succesfully." });
                }
                catch (Exception)
                {
                    throw new Exception();
                }
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
