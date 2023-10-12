using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Implementations
{
    public class LikeAnnouncementCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
