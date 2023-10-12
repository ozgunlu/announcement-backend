using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Implementations
{
    public class DeleteAnnouncementCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
