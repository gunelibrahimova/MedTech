using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class QualityController : Controller
    {
        private readonly QualityServices _sevices;
        private readonly IWebHostEnvironment _environment;

        public QualityController(QualityServices sevices, IWebHostEnvironment environment)
        {
            _sevices = sevices;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var quality = _sevices.GetAll();

            if (quality.Count > 0)
            {
                ViewBag.Sayi = 1;
            }

            else
            {
                ViewBag.Sayi = 0;

            }
            return View(quality);
        }

        public IActionResult Create()
        {
            var quality = _sevices.GetAll();
            if (quality.Count > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, string Description, string Info, string PhotoURL)
        {
            Quality quality = new()
            {
                Title = Title,
                Description = Description,
                Info = Info,
                PhotoURL = PhotoURL
            };

            _sevices.Create(quality);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var quality = _sevices.GetById(id.Value);
            return View(quality);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Quality quality, IFormFile Image, string OldPhoto)
        {

            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _sevices.EditQuality(quality, path);
            }
            else
            {
                _sevices.EditQuality(quality, OldPhoto);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var quality = _sevices.Detail(id.Value);
            return View(quality);
        }

        public IActionResult Delete(int? id)
        {
            _sevices.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
