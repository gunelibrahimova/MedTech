using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class DetailController : Controller
    {
        private readonly DetailServices _services;
        private readonly IWebHostEnvironment _environment;

        public DetailController(DetailServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var detail = _services.GetAll();
            return View(detail);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Detail detail)
        {
            _services.Create(detail);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var detail = _services.GetById(id.Value);
            return View(detail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Detail detail, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditNews(detail, path);
            }
            else
            {
                _services.EditNews(detail, OldPhoto);

            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            var detail = _services.Detail(id.Value);
            return View(detail);
        }

        public IActionResult Delete(int? id)
        {
            _services.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
