using Entities;
using MedTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTech.Controllers
{
    public class AboutController : Controller
    {
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

        public AboutController(HealthyServices healthyServices, ProfessionServices professionServices, QualityServices qualityServices, ProtectServices protectServices, PatientServices patientServices, AboutServices aboutServices, NewsServices newsServices, AppServices appServices, PhotoServices photoServices, SubscribeServices subscribeServices, BookServices bookServices)
        {
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
            AboutVM aboutVM = new()
            {
                healthy = _healthyServices.GetHealthAll(3),
                professions = _professionServices.GetProfessionAll(),
                quality = _qualityServices.GetAll(),
                protects = _protectServices.GetAll(),
                patients = _patientServices.GetAll(),
                about = _aboutServices.GetAll(),
                news = _newsServices.GetAll(),
                apps = _appServices.GetAll(),
                photos = _photoServices.GetAll(),

            };
            return View(aboutVM);
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
