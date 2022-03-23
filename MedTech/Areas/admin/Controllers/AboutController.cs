using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {
        private readonly AboutServices _services;
        private readonly IWebHostEnvironment _environment;

        public AboutController(AboutServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var about = _services.GetAll();
            return View(about);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
             _services.Create(about);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var about = _services.GetById(id.Value);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(About about, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditAbout(about, path);
            }
            else
            {
                _services.EditAbout(about, OldPhoto);

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var about = _services.Detail(id.Value);
            return View(about);
        }

        public async Task<IActionResult> Delete(int? id)
        {
           _services.Delete(id.Value);
            return RedirectToAction(nameof(Index));

        }
    }
}
