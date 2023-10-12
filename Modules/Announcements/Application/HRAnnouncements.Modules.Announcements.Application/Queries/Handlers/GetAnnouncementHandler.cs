using AutoMapper;
using HRAnnouncements.Modules.Announcements.Application.Dtos;
using HRAnnouncements.Modules.Announcements.Application.Queries.Implementations;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Queries.Handlers
{
    public class GetAnnouncementHandler : IRequestHandler<GetAnnouncementQuery, AnnouncementDto>
    {
        private readonly IAnnouncementRepository _repository;
        private readonly IMapper _mapper;

        public GetAnnouncementHandler(
            IAnnouncementRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AnnouncementDto> Handle(GetAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var announcement = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<AnnouncementDto>(announcement);
        }
    }
}
