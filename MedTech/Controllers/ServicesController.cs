using MedTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Controllers
{
    public class ServicesController : Controller
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

        public ServicesController(ILogger<HomeController> logger, HealthyServices healthyServices, ProfessionServices professionServices, QualityServices qualityServices, ProtectServices protectServices, PatientServices patientServices, AboutServices aboutServices, NewsServices newsServices, AppServices appServices, PhotoServices photoServices)
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
        }
        public IActionResult Index()
        {

            ServicesVM servicesVM = new()
            {
                healthy = _healthyServices.GetHealthAll(4),
                professions = _professionServices.GetProfessionForServices(),
                quality = _qualityServices.GetAll(),
                protects = _protectServices.GetAll(),
                patients = _patientServices.GetAll(),
                about = _aboutServices.GetAll(),
                news = _newsServices.GetAll(),
                apps = _appServices.GetAll(),
                photos = _photoServices.GetAll(),

            };
            return View(servicesVM);
        }
    }
}
