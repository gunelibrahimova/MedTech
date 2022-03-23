using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class HealthyController : Controller
    {
        private readonly HealthyServices _services;
        private readonly IWebHostEnvironment _environment;

        public HealthyController(HealthyServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var healthy = _services.GetAll();

            if (healthy.Count > 0)
            {
                ViewBag.Sayi = 1;
            }

            else
            {
                ViewBag.Sayi = 0;

            }
            return View(healthy);
        }


        [HttpGet]
        public IActionResult Create()
        {

            var healthy = _services.GetAll();
            if (healthy.Count > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, string Description, string PhotoURL)
        {
            Healthy healthy = new()
            {
                Title = Title,
                Description = Description,
                PhotoURL = PhotoURL
            };

            _services.Create(healthy);  

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var healthy = _services.GetHealthById(id.Value);
            return View(healthy);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Healthy healthy, IFormFile Image, string OldPhoto)
        {

            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                    _services.EditHealthy(healthy, path);
            }
            else
            {
                _services.EditHealthy(healthy, OldPhoto);

            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            var healthy = _services.Detail(id.Value);
            return View(healthy);
        }

        public IActionResult Delete(int? id)
        {
             _services.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }


    }
}
