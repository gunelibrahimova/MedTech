using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Areas.admin.Controllers
{
    [Area("admin")]
    public class BookController : Controller
    {
        private readonly BookServices _services;

        public BookController(BookServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
