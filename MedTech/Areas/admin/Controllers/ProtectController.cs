using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProtectController : Controller
    {
        private readonly ProtectServices _services;
        private readonly IWebHostEnvironment _environment;

        public ProtectController(ProtectServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var protect = _services.GetAll();
            return View(protect);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Protect protect)
        {
            _services.Create(protect);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
           var protect = _services.GetById(id.Value);
            return View(protect);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Protect protect, IFormFile Image, string PhotoURL, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditProtect(protect, path);
            }
            else
            {
                _services.EditProtect(protect, OldPhoto);

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var protect = _services.Detail(id.Value);
            return View(protect);
        }

        public IActionResult Delete(int? id)
        {
             _services.Delete(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
