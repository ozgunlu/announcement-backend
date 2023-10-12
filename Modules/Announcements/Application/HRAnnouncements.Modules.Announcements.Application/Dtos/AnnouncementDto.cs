namespace HRAnnouncements.Modules.Announcements.Application.Dtos
{
    public class AnnouncementDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public int Likes { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
