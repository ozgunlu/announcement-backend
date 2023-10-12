using HRAnnouncements.Modules.Announcements.Application.Dtos;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Queries.Implementations
{
    public class GetCommentsByAnnouncementQuery : IRequest<IEnumerable<CommentDto>>
    {
        public Guid AnnouncementId { get; }

        public GetCommentsByAnnouncementQuery(Guid announcementId)
        {
            AnnouncementId = announcementId;
        }
    }
}
