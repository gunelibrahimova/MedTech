using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MedTechDbContext : DbContext
    {
        public MedTechDbContext(DbContextOptions<MedTechDbContext> options)
            : base(options) { }

        
        public DbSet<Profession> professions { get; set;}
        public DbSet<Quality> quality { get; set; }
        public DbSet<Protect> protect { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<App> app { get; set; }
        public DbSet<Subscribe> subscriptions { get; set; }
        public DbSet<Photo> photos { get; set; }
        public DbSet<Detail> details { get; set; }
        public DbSet<Skil> skils { get; set; }
        public DbSet<Healthy> health { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
