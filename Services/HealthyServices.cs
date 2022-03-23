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
    public class HealthyServices
    {
        private readonly MedTechDbContext _context;

        public HealthyServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Healthy> GetAll()
        {
            return _context.health.ToList(); 
        }

        public void Create(Healthy healthy)
        {
            _context.Add(healthy);
            _context.SaveChanges();
        }

        public List<Healthy> GetHealthById(int id)
        {
            return _context.health.ToList();
        }

        public void EditHealthy(Healthy healthy,  string PhotoURL)
        {
            
            healthy.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(healthy);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Healthy Detail(int id)
        {
            return _context.health.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var healthy = _context.health.Find(id);
            _context.Remove(healthy);
            _context.SaveChanges();
        }

    }
}
