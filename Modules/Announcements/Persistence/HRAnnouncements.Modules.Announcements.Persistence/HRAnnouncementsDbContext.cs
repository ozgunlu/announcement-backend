using Microsoft.EntityFrameworkCore;
using HRAnnouncements.Modules.Announcements.Domain.Entities;
using HRAnnouncements.Modules.Announcements.Persistence.Configurations;

namespace HRAnnouncements.Modules.Announcements.Persistence
{
    public class HRAnnouncementsDbContext : DbContext
    {
        public HRAnnouncementsDbContext(DbContextOptions<HRAnnouncementsDbContext> options)
        : base(options)
        {
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
        }
    }
}