using Microsoft.EntityFrameworkCore;
using Leaderboard.Repositories;
using Leaderboard.Extensions;
using Leaderboard.Contexts;

namespace Leaderboard.API
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            var token = builder.Configuration.GetValue<string>("Token");

            builder.Services.AddControllers();
            builder.Services.AddDateTimeService();
            builder.Services.AddLeaderboardContext();

            builder.Services.AddScoped(typeof(DbContext), typeof(LeaderboardContext));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseErrorHandling();
            app.UseToken(token);

            app.Run();
        }
    }
}