using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppMvc.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly AppDbContext _context;

        public ProfilesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Profiles.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AaaType,Created,Name,GivenName,AdditionalName,FamilyName,YomiName,GivenNameYomi,AdditionalNameYomi,FamilyNameYomi,NamePrefix,NameSuffix,Initials,Nickname,ShortName,MaidenName,Birthday,Gender,Location,BillingInformation,DirectoryServer,Mileage,Occupation,Hobby,Sensitivity,Priority,Subject,Notes,Language,Photo,GroupMembership,Email1Type,Email1Value,Email2Type,Email2Value,Email3Type,Email3Value,IM1Type,IM1Service,IM1Value,IM2Type,IM2Service,IM2Value,Phone1Type,Phone1Value,Phone2Type,Phone2Value,Phone3Type,Phone3Value,Address1Type,Address1Formatted,Address1Street,Address1City,Address1POBox,Address1Region,Address1PostalCode,Address1Country,Address1ExtendedAddress,Organization1Type,Organization1Name,Organization1YomiName,Organization1Title,Organization1Department,Organization1Symbol,Organization1Location,Organization1JobDescription,Website1Type,Website1Value,Website2Type,Website2Value,Categories,CustomField1Type,CustomField1Value,Event1Type,Event1Value,FileUploaded,FullName,Group,PhotoFileName,ProfileID,Version")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,AaaType,Created,Name,GivenName,AdditionalName,FamilyName,YomiName,GivenNameYomi,AdditionalNameYomi,FamilyNameYomi,NamePrefix,NameSuffix,Initials,Nickname,ShortName,MaidenName,Birthday,Gender,Location,BillingInformation,DirectoryServer,Mileage,Occupation,Hobby,Sensitivity,Priority,Subject,Notes,Language,Photo,GroupMembership,Email1Type,Email1Value,Email2Type,Email2Value,Email3Type,Email3Value,IM1Type,IM1Service,IM1Value,IM2Type,IM2Service,IM2Value,Phone1Type,Phone1Value,Phone2Type,Phone2Value,Phone3Type,Phone3Value,Address1Type,Address1Formatted,Address1Street,Address1City,Address1POBox,Address1Region,Address1PostalCode,Address1Country,Address1ExtendedAddress,Organization1Type,Organization1Name,Organization1YomiName,Organization1Title,Organization1Department,Organization1Symbol,Organization1Location,Organization1JobDescription,Website1Type,Website1Value,Website2Type,Website2Value,Categories,CustomField1Type,CustomField1Value,Event1Type,Event1Value,FileUploaded,FullName,Group,PhotoFileName,ProfileID,Version")] Profile profile)
        {
            if (id != profile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(string id)
        {
            return _context.Profiles.Any(e => e.ID == id);
        }
    }
}
