using Microsoft.EntityFrameworkCore;
using NetCoreDAL.Domain.Entities;

namespace Connect.DataAccess.Infra
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Connect;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Settings> Settings { get; set; }
    }
}
