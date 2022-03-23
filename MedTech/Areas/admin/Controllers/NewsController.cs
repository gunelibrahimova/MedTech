using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class NewsController : Controller
    {
        private readonly NewsServices _services;
        private readonly IWebHostEnvironment _environment;

        public NewsController(NewsServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
             var news =_services.GetAll();
            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(News news)
        {
            _services.Create(news);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var news = _services.GetById(id.Value);
            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(News news, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditNews(news, path);
            }
            else
            {
                _services.EditNews(news, OldPhoto);

            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            var news = _services.Detail(id.Value);
            return View(news);
        }

        public IActionResult Delete(int? id)
        {
            _services.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
