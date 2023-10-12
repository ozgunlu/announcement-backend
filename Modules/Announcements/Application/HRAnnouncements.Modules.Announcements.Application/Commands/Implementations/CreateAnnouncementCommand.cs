using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Implementations
{
    public class CreateAnnouncementCommand : IRequest<Guid>
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
    }
}
