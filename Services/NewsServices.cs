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
    public class NewsServices
    {
        private readonly MedTechDbContext _context;

        public NewsServices(MedTechDbContext context)
        {
            _context = context;
        }
        public List<News> GetAll()
        {
            return _context.news.Take(6).ToList();
        }

        public void Create(News news)
        {
            _context.Add(news);
            _context.SaveChanges();
        }

        public News GetById(int id)
        {
            return _context.news.FirstOrDefault(x => x.Id == id);
        }

        public void EditNews(News news, string PhotoURL)
        {
            news.PhotoURL = PhotoURL;
            var updateEntry = _context.Entry(news);
            updateEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public News Detail(int id)
        {
            return _context.news.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var news = _context.news.Find(id);
            _context.Remove(news);
            _context.SaveChanges();
        }
    }
}
