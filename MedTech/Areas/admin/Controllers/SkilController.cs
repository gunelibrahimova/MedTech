using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class SkilController : Controller
    {
        private readonly SkilServices _services;
        private readonly IWebHostEnvironment _environment;

        public SkilController(SkilServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var skil = _services.GetAll();
            return View(skil);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skil skil)
        {
            _services.Create(skil);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var skil = _services.GetById(id.Value);
            return View(skil);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Skil skil)
        {
             _services.EditSkil(skil);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            var skil = _services.Detail(id.Value);
            return View(skil);
        }

        public IActionResult Delete(int? id)
        {
            _services.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
