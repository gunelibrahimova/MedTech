using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class PhotoController : Controller
    {
        private readonly PhotoServices _services;
        private readonly IWebHostEnvironment _environment;

        public PhotoController(PhotoServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var photo = _services.GetAll();
            return View(photo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Photo photo)
        {
            _services.Create(photo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var photo = _services.GetById(id.Value);
            return View(photo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Photo photo, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditPhoto(photo, path);
            }
            else
            {
                _services.EditPhoto(photo, OldPhoto);

            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            var photo = _services.Detail(id.Value);
            return View(photo);
        }

        public IActionResult Delete(int? id)
        {
            _services.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
