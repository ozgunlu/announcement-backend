using HRAnnouncements.Modules.Announcements.Application.Commands.Implementations;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Commands.Handlers
{
    public class DeleteAnnouncementHandler : IRequestHandler<DeleteAnnouncementCommand, Unit>
    {
        private readonly IAnnouncementRepository _repository;

        public DeleteAnnouncementHandler(IAnnouncementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
