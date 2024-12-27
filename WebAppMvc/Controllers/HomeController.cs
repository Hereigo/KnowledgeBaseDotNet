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
            if (fileToUpload == null || fileToUpload.Length < 1)
            {
                return BadRequest("No file uploaded.");
            }
            else if (string.IsNullOrWhiteSpace(uploadFileType) || !Enum.TryParse(uploadFileType, true, out ProfilesTypes profileType))
            {
                return BadRequest("No file-type selected.");
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

                    var profileParser = new ProfileParser();
                    var result = await profileParser.ParseUploadedProfileAsync(FileNameOnServer, profileType);

                    return Ok(new { message = $"File uploaded to succesfully. - {result}" });
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
