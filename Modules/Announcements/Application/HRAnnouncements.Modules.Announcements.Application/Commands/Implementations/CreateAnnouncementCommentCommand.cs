using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Implementations
{
    public class CreateAnnouncementCommentCommand : IRequest<Guid>
    {
        public Guid AnnouncementId { get; set; }
        public string Content { get; set; } = default!;
    }
}
