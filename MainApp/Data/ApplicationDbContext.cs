// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using MainApp.Models;

namespace MainApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        // Add other DbSets as needed
    }
}