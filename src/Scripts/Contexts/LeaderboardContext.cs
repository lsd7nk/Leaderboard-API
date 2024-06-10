using Microsoft.EntityFrameworkCore;
using Leaderboard.Models;

namespace Leaderboard.Contexts
{
    public sealed class LeaderboardContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public LeaderboardContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }
    }
}
