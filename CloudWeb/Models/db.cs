using Microsoft.EntityFrameworkCore;
using CloudWeb.Models;
using static CloudWeb.Models.Product;
using System.Diagnostics;

namespace CloudWeb.Models
{
    public class db : DbContext
    {
        public static bool value = true;
        public db(DbContextOptions<db> options) : base(options)
        {

            if (value)
            {
                Database.EnsureDeleted();
                value = false;
            } 
            Database.EnsureCreated();

        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Team> Team { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    id = 1,
                    nameCompany = "WevStorm",
                    Location = "Tallinn",
                    basingDate = DateTime.Now,
                    directorName = "Arnold",
                    directorSurname = "Aghh",
                    productType = (Company.branch)productType.Website
                }
            );
        }
    }
}
