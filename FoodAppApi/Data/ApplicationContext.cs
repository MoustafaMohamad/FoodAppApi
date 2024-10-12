using FoodAppApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

namespace FoodAppApi.Data
{
    public class ApplicationContext:DbContext
    {
       // public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FoodApp;Trusted_Connection=True;TrustServerCertificate=True;")
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
               
        }
    }
}
