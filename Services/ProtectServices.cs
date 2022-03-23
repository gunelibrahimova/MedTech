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
    public class ProtectServices
    {
        private readonly MedTechDbContext _context;

        public ProtectServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Protect> GetAll()
        {
            return _context.protect.ToList();
        }

        public void Create(Protect protect)
        {
            _context.Add(protect);
            _context.SaveChanges();
        }

        public Protect GetById(int id)
        {
            return _context.protect.FirstOrDefault(x => x.Id == id);
        }

        public void EditProtect(Protect protect, string PhotoURL)
        {
            protect.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(protect);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Protect Detail(int id)
        {
            return _context.protect.FirstOrDefault(x => x.Id == id);
        }
        
        public void Delete(int id)
        {
            var protect = _context.protect.Find(id);
            _context.Remove(protect);
            _context.SaveChanges();
        }
    }
}
