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
    public class SkilServices
    {
        private readonly MedTechDbContext _context;

        public SkilServices(MedTechDbContext context)
        {
            _context = context;
        }
        public List<Skil> GetAll()
        {
             return _context.skils.ToList();
        }

        public void Create(Skil skil)
        {
            _context.Add(skil);
            _context.SaveChanges();
        }

        public Skil GetById(int id)
        {
            return _context.skils.FirstOrDefault(x => x.Id == id);
        }

        public void EditSkil(Skil skil)
        {
            var updateEntry = _context.Entry(skil);
            updateEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Skil Detail(int id)
        {
            return _context.skils.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var skil = _context.skils.Find(id);
            _context.Remove(skil);
            _context.SaveChanges();
        }
    }
}
