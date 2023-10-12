namespace HRAnnouncements.Modules.Announcements.Application.Dtos
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid AnnouncementId { get; set; }
        public string Content { get; set; } = default!;
        public DateTime DateCommented { get; set; }
    }
}
