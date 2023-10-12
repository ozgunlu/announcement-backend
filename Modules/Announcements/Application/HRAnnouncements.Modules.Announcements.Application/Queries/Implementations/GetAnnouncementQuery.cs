using HRAnnouncements.Modules.Announcements.Application.Dtos;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Queries.Implementations
{
    public class GetAnnouncementQuery : IRequest<AnnouncementDto>
    {
        public Guid Id { get; set; }
    }
}
