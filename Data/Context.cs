using Microsoft.EntityFrameworkCore;
using Models;

namespace ShopAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Orders> Orders {get; set;}
        public DbSet<Products> Products{get; set;}
    }
}