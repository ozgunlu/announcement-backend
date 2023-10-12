using AutoMapper;
using HRAnnouncements.Modules.Announcements.Application.Dtos;
using HRAnnouncements.Modules.Announcements.Application.Queries.Implementations;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Queries.Handlers
{
    public class GetAnnouncementsHandler : IRequestHandler<GetAnnouncementsQuery, AnnouncementListDto>
    {
        private readonly IAnnouncementRepository _repository;
        private readonly IMapper _mapper;

        public GetAnnouncementsHandler(
            IAnnouncementRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _mapper = mapper;
        }

        public async Task<AnnouncementListDto> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            var (announcements, totalRecords) = await _repository.GetAllAsync(request.Filter);

            var announcementDtos = _mapper.Map<IEnumerable<AnnouncementDto>>(announcements);

            return new AnnouncementListDto
            {
                Announcements = announcementDtos,
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = request.Filter.PageNumber,
                    PageSize = request.Filter.PageSize,
                    TotalRecords = totalRecords
                }
            };
        }
    }
}
