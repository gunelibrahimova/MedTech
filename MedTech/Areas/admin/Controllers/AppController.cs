using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class AppController : Controller
    {
        private readonly AppServices _services;
        private readonly IWebHostEnvironment _environment;

        public AppController(AppServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var app = _services.GetAll();

            if (app.Count > 0)
            {
                ViewBag.Sayi = 1;
            }

            else
            {
                ViewBag.Sayi = 0;

            }
            return View(app);
        }

        public IActionResult Create()
        {
            var app = _services.GetAll();
            if (app.Count > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(App app)
        {
            _services.Create(app);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var app = _services.GetById(id.Value);
            return View(app);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(App app, IFormFile Image, string OldPhoto)
        {

            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditApp(app, path);
            }
            else
            {
                _services.EditApp(app, OldPhoto);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var app = _services.Detail(id.Value);
            return View(app);
        }

        public IActionResult Delete(int? id)
        {
            _services.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
