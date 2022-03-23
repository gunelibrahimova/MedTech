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
    public class QualityServices
    {
        private readonly MedTechDbContext _context;

        public QualityServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Quality> GetAll()
        {
            return _context.quality.ToList();
        }

        public void Create(Quality quality)
        {
            _context.Add(quality);
            _context.SaveChanges();
        }

        public Quality GetById(int id)
        {
            return _context.quality.FirstOrDefault(x => x.Id == id);
        }

        public void EditQuality(Quality quality , string PhotoURL)
        {

            quality.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(quality);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Quality Detail(int id)
        {
            return _context.quality.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var quality = _context.quality.Find(id);
            _context.Remove(quality);
            _context.SaveChanges();
        }
    }
}
