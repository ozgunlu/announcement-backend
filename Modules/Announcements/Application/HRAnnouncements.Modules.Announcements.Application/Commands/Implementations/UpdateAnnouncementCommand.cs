using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Implementations
{
    public class UpdateAnnouncementCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
