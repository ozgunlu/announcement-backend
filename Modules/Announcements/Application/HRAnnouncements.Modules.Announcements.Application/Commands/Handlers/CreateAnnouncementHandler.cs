using HRAnnouncements.Modules.Announcements.Application.Commands.Implementations;
using HRAnnouncements.Modules.Announcements.Domain.Entities;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Handlers
{
    public class CreateAnnouncementHandler : IRequestHandler<CreateAnnouncementCommand, Guid>
    {
        private readonly IAnnouncementRepository _repository;

        public CreateAnnouncementHandler(IAnnouncementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = Announcement.Create(
                request.Title,
                request.Content
            );

            await _repository.AddAsync(announcement);
            return announcement.Id;
        }
    }
}
