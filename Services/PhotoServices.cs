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
    public class PhotoServices
    {
        private readonly MedTechDbContext _context;

        public PhotoServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Photo> GetAll()
        {
            return _context.photos.ToList();
        }

        public void Create(Photo photo)
        {
            _context.Add(photo);
            _context.SaveChanges();
        }

        public Photo GetById(int id)
        {
            return _context.photos.FirstOrDefault(x => x.Id == id);
        }

        public void EditPhoto(Photo photo, string PhotoURL)
        {
            photo.PhotoURL = PhotoURL;
            var updateEntry = _context.Entry(photo);
            updateEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Photo Detail(int id)
        {
            return _context.photos.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var photo = _context.photos.Find(id);
            _context.Remove(photo);
            _context.SaveChanges();
        }
    }
}
