namespace HRAnnouncements.Modules.Announcements.Domain.Filters
{
    public class AnnouncementFilter
    {
        public string? Title { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
