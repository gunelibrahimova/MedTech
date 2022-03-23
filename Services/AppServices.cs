using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppServices
    {
        private readonly MedTechDbContext _context;

        public AppServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<App> GetAll()
        {
            return _context.app.ToList();
        }

        
        public void Create(App app)
        {
            _context.Add(app);
            _context.SaveChanges();
        }


        public App GetById(int id)
        {
            return _context.app.FirstOrDefault(x => x.Id == id);
        }

        public void EditApp(App app, string PhotoURL)
        {

            app.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(app);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public App Detail(int id)
        {
            return _context.app.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var app = _context.app.Find(id);
            _context.Remove(app);
            _context.SaveChanges();
        }
    }
}
