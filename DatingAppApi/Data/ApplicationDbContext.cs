using DatingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAppApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}


    }
}
