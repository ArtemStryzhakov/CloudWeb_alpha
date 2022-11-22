using Microsoft.EntityFrameworkCore;
using CloudWeb.Models;

namespace CloudWeb.Models
{
    public class db : DbContext
    {
        public static bool value = true;
        public db(DbContextOptions<db> options) : base(options) {

            /*if (value)
            {
                Database.EnsureDeleted();
                value = false;
            } 
            Database.EnsureCreated();*/
            
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Team> Team { get; set; }
    }
}
