using System.Diagnostics;
using System.Text;
using System.Text.Json;
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
            else
            {
                try
                {
                    string fileContent = await ReadFileContentAsync(fileToUpload);
                    var profileParser = new ProfileParser(_mapper);

                    IEnumerable<AProfile> result = await profileParser.ParseUploadedProfileAsync(fileToUpload.ContentType, fileToUpload.FileName, fileContent);

                    var tempFilePath = Path.Combine(
                        new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, 
                        DateTime.Now.ToString("yyMMddHHmmss.txt"));

                    foreach (AProfile profile in result)
                    {
                        if (!profileExists(profile))
                        {
                            string temp = JsonSerializer.Serialize(profile);

                            if (!System.IO.File.Exists(tempFilePath))
                            {
                                System.IO.File.Create(tempFilePath);
                            }
                            System.IO.File.WriteAllText(tempFilePath, temp);
                            System.IO.File.WriteAllText(tempFilePath, Environment.NewLine);
                        }

                        profile.Created = DateTime.Now;

                        if (string.IsNullOrWhiteSpace(profile.Name) ||
                            string.IsNullOrWhiteSpace(profile.GivenName) ||
                            string.IsNullOrWhiteSpace(profile.AdditionalName) ||
                            string.IsNullOrWhiteSpace(profile.FamilyName))
                        {
                            profile.IsBroken = true;
                        }

                        // TODO:
                        // Check for Empty Names and Phones...
                        // Check for Already existed records!

                        //throw new NotImplementedException();

                        _appDbContext.Profiles.AddRange(result);
                        _appDbContext.SaveChanges();
                    }

                    return Ok(new { message = $"File uploaded to succesfully. - {result}" });
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
        }

        private bool profileExists(AProfile newItem)
        {
            return _appDbContext.Profiles.Any(item =>
            (string.IsNullOrEmpty(item.AdditionalName) ? string.IsNullOrEmpty(newItem.AdditionalName) : item.AdditionalName == newItem.AdditionalName) &&
            //(string.IsNullOrEmpty(item.AdditionalNameYomi) ? string.IsNullOrEmpty(newItem.AdditionalNameYomi) : item.AdditionalNameYomi == newItem.AdditionalNameYomi) &&
            (string.IsNullOrEmpty(item.Address1City) ? string.IsNullOrEmpty(newItem.Address1City) : item.Address1City == newItem.Address1City) &&
            (string.IsNullOrEmpty(item.Address1Country) ? string.IsNullOrEmpty(newItem.Address1Country) : item.Address1Country == newItem.Address1Country) &&
            (string.IsNullOrEmpty(item.Address1ExtendedAddress) ? string.IsNullOrEmpty(newItem.Address1ExtendedAddress) : item.Address1ExtendedAddress == newItem.Address1ExtendedAddress) &&
            (string.IsNullOrEmpty(item.Address1Formatted) ? string.IsNullOrEmpty(newItem.Address1Formatted) : item.Address1Formatted == newItem.Address1Formatted) &&
            (string.IsNullOrEmpty(item.Address1POBox) ? string.IsNullOrEmpty(newItem.Address1POBox) : item.Address1POBox == newItem.Address1POBox) &&
            (string.IsNullOrEmpty(item.Address1PostalCode) ? string.IsNullOrEmpty(newItem.Address1PostalCode) : item.Address1PostalCode == newItem.Address1PostalCode) &&
            (string.IsNullOrEmpty(item.Address1Region) ? string.IsNullOrEmpty(newItem.Address1Region) : item.Address1Region == newItem.Address1Region) &&
            (string.IsNullOrEmpty(item.Address1Street) ? string.IsNullOrEmpty(newItem.Address1Street) : item.Address1Street == newItem.Address1Street) &&
            (string.IsNullOrEmpty(item.Address1Type) ? string.IsNullOrEmpty(newItem.Address1Type) : item.Address1Type == newItem.Address1Type) &&
            (string.IsNullOrEmpty(item.BillingInformation) ? string.IsNullOrEmpty(newItem.BillingInformation) : item.BillingInformation == newItem.BillingInformation) &&
            (string.IsNullOrEmpty(item.Birthday) ? string.IsNullOrEmpty(newItem.Birthday) : item.Birthday == newItem.Birthday) &&
            (string.IsNullOrEmpty(item.Categories) ? string.IsNullOrEmpty(newItem.Categories) : item.Categories == newItem.Categories) &&
            (string.IsNullOrEmpty(item.CustomField1Type) ? string.IsNullOrEmpty(newItem.CustomField1Type) : item.CustomField1Type == newItem.CustomField1Type) &&
            (string.IsNullOrEmpty(item.CustomField1Value) ? string.IsNullOrEmpty(newItem.CustomField1Value) : item.CustomField1Value == newItem.CustomField1Value) &&
            (string.IsNullOrEmpty(item.DirectoryServer) ? string.IsNullOrEmpty(newItem.DirectoryServer) : item.DirectoryServer == newItem.DirectoryServer) &&
            (string.IsNullOrEmpty(item.Email1Type) ? string.IsNullOrEmpty(newItem.Email1Type) : item.Email1Type == newItem.Email1Type) &&
            (string.IsNullOrEmpty(item.Email1Value) ? string.IsNullOrEmpty(newItem.Email1Value) : item.Email1Value == newItem.Email1Value) &&
            (string.IsNullOrEmpty(item.Email2Type) ? string.IsNullOrEmpty(newItem.Email2Type) : item.Email2Type == newItem.Email2Type) &&
            (string.IsNullOrEmpty(item.Email2Value) ? string.IsNullOrEmpty(newItem.Email2Value) : item.Email2Value == newItem.Email2Value) &&
            (string.IsNullOrEmpty(item.Email3Type) ? string.IsNullOrEmpty(newItem.Email3Type) : item.Email3Type == newItem.Email3Type) &&
            (string.IsNullOrEmpty(item.Email3Value) ? string.IsNullOrEmpty(newItem.Email3Value) : item.Email3Value == newItem.Email3Value) &&
            (string.IsNullOrEmpty(item.Event1Type) ? string.IsNullOrEmpty(newItem.Event1Type) : item.Event1Type == newItem.Event1Type) &&
            (string.IsNullOrEmpty(item.Event1Value) ? string.IsNullOrEmpty(newItem.Event1Value) : item.Event1Value == newItem.Event1Value) &&
            (string.IsNullOrEmpty(item.FamilyName) ? string.IsNullOrEmpty(newItem.FamilyName) : item.FamilyName == newItem.FamilyName) &&
            //(string.IsNullOrEmpty(item.FamilyNameYomi) ? string.IsNullOrEmpty(newItem.FamilyNameYomi) : item.FamilyNameYomi == newItem.FamilyNameYomi) &&
            (string.IsNullOrEmpty(item.FileUploaded) ? string.IsNullOrEmpty(newItem.FileUploaded) : item.FileUploaded == newItem.FileUploaded) &&
            (string.IsNullOrEmpty(item.FullName) ? string.IsNullOrEmpty(newItem.FullName) : item.FullName == newItem.FullName) &&
            (string.IsNullOrEmpty(item.Gender) ? string.IsNullOrEmpty(newItem.Gender) : item.Gender == newItem.Gender) &&
            (string.IsNullOrEmpty(item.GivenName) ? string.IsNullOrEmpty(newItem.GivenName) : item.GivenName == newItem.GivenName) &&
            //(string.IsNullOrEmpty(item.GivenNameYomi) ? string.IsNullOrEmpty(newItem.GivenNameYomi) : item.GivenNameYomi == newItem.GivenNameYomi) &&
            (string.IsNullOrEmpty(item.Group) ? string.IsNullOrEmpty(newItem.Group) : item.Group == newItem.Group) &&
            (string.IsNullOrEmpty(item.GroupMembership) ? string.IsNullOrEmpty(newItem.GroupMembership) : item.GroupMembership == newItem.GroupMembership) &&
            (string.IsNullOrEmpty(item.Hobby) ? string.IsNullOrEmpty(newItem.Hobby) : item.Hobby == newItem.Hobby) &&
            (string.IsNullOrEmpty(item.IM1Service) ? string.IsNullOrEmpty(newItem.IM1Service) : item.IM1Service == newItem.IM1Service) &&
            (string.IsNullOrEmpty(item.IM1Type) ? string.IsNullOrEmpty(newItem.IM1Type) : item.IM1Type == newItem.IM1Type) &&
            (string.IsNullOrEmpty(item.IM1Value) ? string.IsNullOrEmpty(newItem.IM1Value) : item.IM1Value == newItem.IM1Value) &&
            (string.IsNullOrEmpty(item.IM2Service) ? string.IsNullOrEmpty(newItem.IM2Service) : item.IM2Service == newItem.IM2Service) &&
            (string.IsNullOrEmpty(item.IM2Type) ? string.IsNullOrEmpty(newItem.IM2Type) : item.IM2Type == newItem.IM2Type) &&
            (string.IsNullOrEmpty(item.IM2Value) ? string.IsNullOrEmpty(newItem.IM2Value) : item.IM2Value == newItem.IM2Value) &&
            (string.IsNullOrEmpty(item.Initials) ? string.IsNullOrEmpty(newItem.Initials) : item.Initials == newItem.Initials) &&
            (string.IsNullOrEmpty(item.Language) ? string.IsNullOrEmpty(newItem.Language) : item.Language == newItem.Language) &&
            (string.IsNullOrEmpty(item.Location) ? string.IsNullOrEmpty(newItem.Location) : item.Location == newItem.Location) &&
            (string.IsNullOrEmpty(item.MaidenName) ? string.IsNullOrEmpty(newItem.MaidenName) : item.MaidenName == newItem.MaidenName) &&
            (string.IsNullOrEmpty(item.Mileage) ? string.IsNullOrEmpty(newItem.Mileage) : item.Mileage == newItem.Mileage) &&
            (string.IsNullOrEmpty(item.Name) ? string.IsNullOrEmpty(newItem.Name) : item.Name == newItem.Name) &&
            (string.IsNullOrEmpty(item.NamePrefix) ? string.IsNullOrEmpty(newItem.NamePrefix) : item.NamePrefix == newItem.NamePrefix) &&
            (string.IsNullOrEmpty(item.NameSuffix) ? string.IsNullOrEmpty(newItem.NameSuffix) : item.NameSuffix == newItem.NameSuffix) &&
            (string.IsNullOrEmpty(item.Nickname) ? string.IsNullOrEmpty(newItem.Nickname) : item.Nickname == newItem.Nickname) &&
            (string.IsNullOrEmpty(item.Notes) ? string.IsNullOrEmpty(newItem.Notes) : item.Notes == newItem.Notes) &&
            (string.IsNullOrEmpty(item.Occupation) ? string.IsNullOrEmpty(newItem.Occupation) : item.Occupation == newItem.Occupation) &&
            (string.IsNullOrEmpty(item.Organization1Department) ? string.IsNullOrEmpty(newItem.Organization1Department) : item.Organization1Department == newItem.Organization1Department) &&
            (string.IsNullOrEmpty(item.Organization1JobDescription) ? string.IsNullOrEmpty(newItem.Organization1JobDescription) : item.Organization1JobDescription == newItem.Organization1JobDescription) &&
            (string.IsNullOrEmpty(item.Organization1Location) ? string.IsNullOrEmpty(newItem.Organization1Location) : item.Organization1Location == newItem.Organization1Location) &&
            (string.IsNullOrEmpty(item.Organization1Name) ? string.IsNullOrEmpty(newItem.Organization1Name) : item.Organization1Name == newItem.Organization1Name) &&
            (string.IsNullOrEmpty(item.Organization1Symbol) ? string.IsNullOrEmpty(newItem.Organization1Symbol) : item.Organization1Symbol == newItem.Organization1Symbol) &&
            (string.IsNullOrEmpty(item.Organization1Title) ? string.IsNullOrEmpty(newItem.Organization1Title) : item.Organization1Title == newItem.Organization1Title) &&
            (string.IsNullOrEmpty(item.Organization1Type) ? string.IsNullOrEmpty(newItem.Organization1Type) : item.Organization1Type == newItem.Organization1Type) &&
            (string.IsNullOrEmpty(item.Organization1YomiName) ? string.IsNullOrEmpty(newItem.Organization1YomiName) : item.Organization1YomiName == newItem.Organization1YomiName) &&
            (string.IsNullOrEmpty(item.Phone1Type) ? string.IsNullOrEmpty(newItem.Phone1Type) : item.Phone1Type == newItem.Phone1Type) &&
            (string.IsNullOrEmpty(item.Phone1Value) ? string.IsNullOrEmpty(newItem.Phone1Value) : item.Phone1Value == newItem.Phone1Value) &&
            (string.IsNullOrEmpty(item.Phone2Type) ? string.IsNullOrEmpty(newItem.Phone2Type) : item.Phone2Type == newItem.Phone2Type) &&
            (string.IsNullOrEmpty(item.Phone2Value) ? string.IsNullOrEmpty(newItem.Phone2Value) : item.Phone2Value == newItem.Phone2Value) &&
            (string.IsNullOrEmpty(item.Phone3Type) ? string.IsNullOrEmpty(newItem.Phone3Type) : item.Phone3Type == newItem.Phone3Type) &&
            (string.IsNullOrEmpty(item.Phone3Value) ? string.IsNullOrEmpty(newItem.Phone3Value) : item.Phone3Value == newItem.Phone3Value) &&
            (string.IsNullOrEmpty(item.Photo) ? string.IsNullOrEmpty(newItem.Photo) : item.Photo == newItem.Photo) &&
            (string.IsNullOrEmpty(item.PhotoFileName) ? string.IsNullOrEmpty(newItem.PhotoFileName) : item.PhotoFileName == newItem.PhotoFileName) &&
            (string.IsNullOrEmpty(item.Priority) ? string.IsNullOrEmpty(newItem.Priority) : item.Priority == newItem.Priority) &&
            (string.IsNullOrEmpty(item.ProfileID) ? string.IsNullOrEmpty(newItem.ProfileID) : item.ProfileID == newItem.ProfileID) &&
            (string.IsNullOrEmpty(item.Sensitivity) ? string.IsNullOrEmpty(newItem.Sensitivity) : item.Sensitivity == newItem.Sensitivity) &&
            (string.IsNullOrEmpty(item.ShortName) ? string.IsNullOrEmpty(newItem.ShortName) : item.ShortName == newItem.ShortName) &&
            (string.IsNullOrEmpty(item.Subject) ? string.IsNullOrEmpty(newItem.Subject) : item.Subject == newItem.Subject) &&
            // (string.IsNullOrEmpty(item.Version) ? string.IsNullOrEmpty(newItem.Version) : item.Version == newItem.Version) &&
            (string.IsNullOrEmpty(item.Website1Type) ? string.IsNullOrEmpty(newItem.Website1Type) : item.Website1Type == newItem.Website1Type) &&
            (string.IsNullOrEmpty(item.Website1Value) ? string.IsNullOrEmpty(newItem.Website1Value) : item.Website1Value == newItem.Website1Value) &&
            (string.IsNullOrEmpty(item.Website2Type) ? string.IsNullOrEmpty(newItem.Website2Type) : item.Website2Type == newItem.Website2Type) &&
            (string.IsNullOrEmpty(item.Website2Value) ? string.IsNullOrEmpty(newItem.Website2Value) : item.Website2Value == newItem.Website2Value) 
            // &&
            //(string.IsNullOrEmpty(item.YomiName) ? string.IsNullOrEmpty(newItem.YomiName) : item.YomiName == newItem.YomiName)
            );
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
