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
    public class BookServices
    {
        private readonly MedTechDbContext _context;

        public BookServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.books.ToList();
        }

        public void Post(Book book)
        {
            _context.books.Add(book);
            _context.SaveChanges();
        }
    }
}
