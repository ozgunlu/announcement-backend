namespace HRAnnouncements.Modules.Announcements.Application.Dtos
{
    public class AnnouncementListDto
    {
        public IEnumerable<AnnouncementDto> Announcements { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }

}
