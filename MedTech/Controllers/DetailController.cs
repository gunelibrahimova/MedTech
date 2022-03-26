using Entities;
using MedTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Controllers
{
    public class DetailController : Controller
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

        public DetailController(ILogger<HomeController> logger, HealthyServices healthyServices, ProfessionServices professionServices, QualityServices qualityServices, ProtectServices protectServices, PatientServices patientServices, AboutServices aboutServices, NewsServices newsServices, AppServices appServices, PhotoServices photoServices, DetailServices detailServices, SkilServices skyServices, SubscribeServices subscribeServices)
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
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                healthy = _healthyServices.GetAll(),
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

            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Index(Subscribe subscribe)
        {
            _subscribeServices.Post(subscribe);
            return RedirectToAction(nameof(Index));
        }
    }
}
