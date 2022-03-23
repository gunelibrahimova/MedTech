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
    public class ProfessionServices
    {
        private readonly MedTechDbContext _context;

        public ProfessionServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Profession> GetAll()
        {
            var profession = _context.professions.ToList();
            return profession;
        }

        public void Create(Profession profession)
        {
            _context.Add(profession);
            _context.SaveChanges();
        }

        public List<Profession> GetProfessionAll()
        {
            return _context.professions.Take(3).ToList();
        }

        public Profession GetById(int id )
        {
            return _context.professions.FirstOrDefault(x=>x.Id == id);
        }

        public void EditProfession(Profession profession, string PhotoURL)
        {

            profession.PhotoURL = PhotoURL;
            var updatedEntity = _context.Entry(profession);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Profession Detail(int id)
        {
            return _context.professions.FirstOrDefault(x=>x.Id == id);
        }

        public void Delete(int id)
        {
            var profession = _context.professions.Find(id);
            _context.Remove(profession);
            _context.SaveChanges();
        }
    }
}
