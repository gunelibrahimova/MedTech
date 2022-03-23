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
    public class AboutServices
    {
        private readonly MedTechDbContext _context;

        public AboutServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<About> GetAll()
        {
           return _context.abouts.ToList();
        }

        public void Create(About about)
        {
            _context.Add(about);
            _context.SaveChanges();
        }

        public About GetById(int id)
        {
            return _context.abouts.FirstOrDefault(x=>x.Id == id);
        }

        public void EditAbout(About about, string PhotoURL)
        {
            about.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(about);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public About Detail (int id)
        {
            return _context.abouts.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var about = _context.abouts.Find(id);
            _context.Remove(about);
            _context.SaveChanges();
        }
    }
}
