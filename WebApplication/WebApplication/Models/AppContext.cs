using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class AppContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WebAppUsers;Trusted_Connection=True;");
        }
    }
}
