// DataAccess/Concrete/EntityFramework/ChinookContext.cs
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ChinookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"Server=(localdb)\MSSQLLocalDB;
                Database=Chinook;
                Trusted_Connection=true");
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Track> Track { get; set; }
    }
}