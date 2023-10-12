using HRAnnouncements.Modules.Announcements.Application.Dtos;
using HRAnnouncements.Modules.Announcements.Domain.Filters;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Queries.Implementations
{
    public class GetAnnouncementsQuery : IRequest<AnnouncementListDto>
    {
        public AnnouncementFilter Filter { get; set; } = new AnnouncementFilter();
    }
}
