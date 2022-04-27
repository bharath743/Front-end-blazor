using FrondEnd.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontEnd.Api.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private string databasePath;

        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        public ApplicationDbContext()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            databasePath = Path.Join(folder, "ApplicationDataBase.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }
    }
}
