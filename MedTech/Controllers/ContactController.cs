using Entities;
using MedTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Controllers
{
    public class ContactController : Controller
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
        private readonly SubscribeServices _subscribeServices;
        private readonly BookServices _bookServices;

        public ContactController(ILogger<HomeController> logger, HealthyServices healthyServices, ProfessionServices professionServices, QualityServices qualityServices, ProtectServices protectServices, PatientServices patientServices, AboutServices aboutServices, NewsServices newsServices, AppServices appServices, PhotoServices photoServices, SubscribeServices subscribeServices, BookServices bookServices)
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
            _subscribeServices = subscribeServices;
            _bookServices = bookServices;
        }
        public IActionResult Index()
        {
            ContactVM contactVM = new()
            {
                healthy = _healthyServices.GetHealthAll(6),
                professions = _professionServices.GetProfessionForContact(),
                quality = _qualityServices.GetAll(),
                protects = _protectServices.GetAll(),
                patients = _patientServices.GetPatientAll(),
                about = _aboutServices.GetAll(),
                news = _newsServices.GetAll(),
                apps = _appServices.GetAll(),
                photos = _photoServices.GetAll(),

            };
            return View(contactVM);
        }

        [HttpPost]
        public IActionResult Index(Subscribe subscribe, Book book)
        {
            if (book.Name == null & book.Message == null & book.Date == null)
            {
                _subscribeServices.Post(subscribe);
            }
            else
            {
                _bookServices.Post(book);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
