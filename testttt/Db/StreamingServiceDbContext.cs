using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Db
{
    public class StreamingServiceDbContext : DbContext
   {
        public StreamingServiceDbContext(DbContextOptions<StreamingServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actor { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }
}
