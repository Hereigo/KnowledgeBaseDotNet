using System.Diagnostics;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models;

namespace WebAppMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, IMapper mapper)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _mapper = mapper;
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
            //else if (string.IsNullOrWhiteSpace(uploadFileType) || !Enum.TryParse(uploadFileType, true, out ProfilesTypes profileType))
            //{
            //    return BadRequest("No file-type selected.");
            //}
            else
            {
                try
                {
                    //string FileNameOnServer = Path.GetTempPath();
                    //FileNameOnServer += fileToUpload.FileName;

                    //long FileContentLength = fileToUpload.Length; // bytes
                    //string FileContentType = fileToUpload.ContentType;

                    string fileContent = await ReadFileContentAsync(fileToUpload);

                    //using var stream = System.IO.File.Create(FileNameOnServer);
                    //fileToUpload.CopyTo(stream);
                    //stream.Flush();

                    var profileParser = new ProfileParser(_mapper);

                    IEnumerable<FullProfile> result = await profileParser.ParseUploadedProfileAsync(fileToUpload.ContentType, fileToUpload.FileName, fileContent);

                    foreach (FullProfile profile in result) 
                    {
                        profile.Created = DateTime.Now;
                    }

                    _appDbContext.Profiles.AddRange(result);
                    _appDbContext.SaveChanges();

                    return Ok(new { message = $"File uploaded to succesfully. - {result}" });
                }
                catch (Exception ex)
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

        private async Task<string> ReadFileContentAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream); // Copy file content to memory
                memoryStream.Seek(0, SeekOrigin.Begin); // Rewind the memory stream
                using (var reader = new StreamReader(memoryStream, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync(); // Read file content as string
                }
            }
        }
    }
}
