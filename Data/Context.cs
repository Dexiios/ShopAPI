using Microsoft.EntityFrameworkCore;
using Models;

namespace ShopAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
        public DbSet<Customers> Customers {get; set;}
        public DbSet<Orders> Orders {get; set;}
        public DbSet<Products> Products{get; set;}
    }
}