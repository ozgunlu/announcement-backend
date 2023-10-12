using HRAnnouncements.Modules.Announcements.Application.Commands.Implementations;
using HRAnnouncements.Modules.Announcements.Application.Exceptions;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Handlers
{
    public class UpdateAnnouncementHandler : IRequestHandler<UpdateAnnouncementCommand, Unit>
    {
        private readonly IAnnouncementRepository _repository;

        public UpdateAnnouncementHandler(IAnnouncementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _repository.GetByIdAsync(request.Id);

            if (announcement == null)
            {
                throw new NotFoundException($"Announcement with ID {request.Id} not found.");
            }

            announcement.ChangeTitle(request.Title);
            announcement.ChangeContent(request.Content);

            await _repository.UpdateAsync(announcement); 

            return Unit.Value;
        }
    }
}
