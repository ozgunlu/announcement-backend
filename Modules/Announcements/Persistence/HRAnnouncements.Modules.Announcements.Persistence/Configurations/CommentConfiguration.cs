using HRAnnouncements.Modules.Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRAnnouncements.Modules.Announcements.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.AnnouncementId)
                .IsRequired();

            builder.Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(1000); 

            builder.Property(c => c.DateCommented)
                .IsRequired();

            builder.HasOne<Announcement>()  
                .WithMany()  
                .HasForeignKey(c => c.AnnouncementId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
