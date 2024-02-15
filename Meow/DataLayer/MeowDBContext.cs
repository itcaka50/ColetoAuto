using BussinessLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MeowDbContext : IdentityDbContext<User>
    {
        public MeowDbContext() : base()
        {

        }

        public MeowDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\DEFAULTSQLSERVER;Database=MeowDB2;Trusted_Connection=True;Encrypt=False");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<Boat> Boats { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }
    }
}
