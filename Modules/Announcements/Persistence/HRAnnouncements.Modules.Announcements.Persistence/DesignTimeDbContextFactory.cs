using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HRAnnouncements.Modules.Announcements.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HRAnnouncementsDbContext>
    {
        public HRAnnouncementsDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\API\HRAnnouncements.Modules.Announcements.API"));

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) 
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<HRAnnouncementsDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(connectionString);

            return new HRAnnouncementsDbContext(builder.Options);
        }
    }
}
