using Entities;
using MedTech.Models;
using MedTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace MedTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HealthyServices _healthyServices;
        private readonly ProfessionServices _professionServices;
        private readonly QualityServices _qualityServices;
        private readonly ProtectServices _protectServices;
        private readonly PatientServices _patientServices;
        private readonly AboutServices _aboutServices;
        private readonly NewsServices _newsServices;
        private readonly AppServices _appServices;
        private readonly PhotoServices _photoServices;
        private readonly DetailServices _detailServices;
        private readonly SkilServices _skyServices;
        private readonly SubscribeServices _subscribeServices;
        private readonly BookServices _bookServices;


        public HomeController(ILogger<HomeController> logger, HealthyServices healthyServices, ProfessionServices professionServices, QualityServices qualityServices, ProtectServices protectServices, PatientServices patientServices, AboutServices aboutServices, NewsServices newsServices, AppServices appServices, PhotoServices photoServices, DetailServices detailServices, SkilServices skyServices, SubscribeServices subscribeServices, BookServices bookServices)
        {
            _logger = logger;
            _healthyServices = healthyServices;
            _professionServices = professionServices;
            _qualityServices = qualityServices;
            _protectServices = protectServices;
            _patientServices = patientServices;
            _aboutServices = aboutServices;
            _newsServices = newsServices;
            _appServices = appServices;
            _photoServices = photoServices;
            _detailServices = detailServices;
            _skyServices = skyServices;
            _subscribeServices = subscribeServices;
            _bookServices = bookServices;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                healthy = _healthyServices.GetHealthAll(1),
                professions = _professionServices.GetAll(),
                quality = _qualityServices.GetAll(),
                protects = _protectServices.GetAll(),
                patients = _patientServices.GetAll(),
                about = _aboutServices.GetAll(),
                news = _newsServices.GetAll(),
                apps = _appServices.GetAll(),
                photos = _photoServices.GetAll(),
                details = _detailServices.GetAll(),
                skils = _skyServices.GetAll(),
                books = _bookServices.GetAll(),
            };



            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Index(Subscribe subscribe, Book book)
        {
            if (book.Name ==null & book.Message == null & book.Date == null)
            {
                _subscribeServices.Post(subscribe);
            }
            else
            {
                _bookServices.Post(book);
            }
           
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}