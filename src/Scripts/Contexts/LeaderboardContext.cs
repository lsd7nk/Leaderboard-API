using Microsoft.EntityFrameworkCore;
using Leaderboard.Models;

namespace Leaderboard.Contexts
{
    public sealed class LeaderboardContext : DbContext
    {
        private const string APP_SETTINGS_FILE = "appsettings.json";
        private const string CONNECTION_STRING_NAME = "DefaultConnection";

        public DbSet<User> Users { get; set; }

        public LeaderboardContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile(APP_SETTINGS_FILE)
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

            optionsBuilder.UseSqlite(config.GetConnectionString(CONNECTION_STRING_NAME));
        }
    }
}
