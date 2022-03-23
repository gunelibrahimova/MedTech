    using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProfessionController : Controller
    {
        private readonly ProfessionServices _services;
        private readonly IWebHostEnvironment _environment;

        public ProfessionController(ProfessionServices services, IWebHostEnvironment webHostEnvironment)
        {
            _services = services;
            _environment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var profession = _services.GetAll();
            return View(profession);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(string Title, string Description, string PhotoURL)
        {
            Profession profession = new()
            {
                Title = Title,
                Description = Description,
                PhotoURL = PhotoURL
            };

            _services.Create(profession);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var profession = _services.GetById(id.Value);
            return View(profession);
        }

        

        [HttpPost]
        public async Task<IActionResult> Edit(Profession profession, IFormFile Image, string OldPhoto)
        {

            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditProfession(profession, path);
            }
            else
            {
                _services.EditProfession(profession, OldPhoto);

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var profession = _services.Detail(id.Value);
            return View(profession);
        }

        public IActionResult Delete(int? id)
        {
             _services.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }


    }
}
