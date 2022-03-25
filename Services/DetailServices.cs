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
    public class DetailServices
    {
        private readonly MedTechDbContext _context;

        public DetailServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Detail> GetAll()
        {
            return _context.details.ToList();
        }

        public void Create(Detail detail)
        {
            _context.Add(detail);
            _context.SaveChanges();
        }

        public Detail GetById(int id)
        {
            return _context.details.FirstOrDefault(x => x.Id == id);
        }

        public void EditNews(Detail detail, string PhotoURL)
        {
            detail.PhotoURL = PhotoURL;
            var updateEntry = _context.Entry(detail);
            updateEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Detail Detail(int id)
        {
            return _context.details.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var detail = _context.details.Find(id);
            _context.Remove(detail);
            _context.SaveChanges();
        }
    }
}
