using Entities;

namespace MedTech.ViewModel
{
    public class TeamVM
    {
        public List<Healthy> healthy { get; set; }
        public List<Profession> professions { get; set; }
        public List<Quality> quality { get; set; }
        public List<Patient> patients { get; set; }
        public List<Protect> protects { get; set; }
        public List<About> about { get; set; }
        public List<News> news { get; set; }
        public List<App> apps { get; set; }
        public List<Photo> photos { get; set; }
        public List<Detail> details { get; set; }
    }
}
