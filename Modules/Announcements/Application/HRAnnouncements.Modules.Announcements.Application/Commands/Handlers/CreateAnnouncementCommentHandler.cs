using HRAnnouncements.Modules.Announcements.Application.Commands.Implementations;
using HRAnnouncements.Modules.Announcements.Domain.Entities;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Handlers
{
    public class CreateAnnouncementCommentHandler : IRequestHandler<CreateAnnouncementCommentCommand, Guid>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateAnnouncementCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Guid> Handle(CreateAnnouncementCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = Comment.Create(request.AnnouncementId, request.Content);

            await _commentRepository.AddAsync(comment);

            return comment.Id;
        }
    }
}
