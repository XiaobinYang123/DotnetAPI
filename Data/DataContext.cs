using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Model;
using WebApplicationAPI.Models;
// database and framwork
namespace WebApplicationAPI.Data
{
    public class DataContext : DbContext
    {
        // ctor short cut
        public DataContext(DbContextOptions<DataContext> options) : base(options)  
        {
            
        }
        public DbSet<Value> Values { get; set; }

        public DbSet<User> Users { get; set; } // tell the entity framework we have user model, apply migration to our database

        public DbSet<Photo> Photos { get; set;}
    }
}