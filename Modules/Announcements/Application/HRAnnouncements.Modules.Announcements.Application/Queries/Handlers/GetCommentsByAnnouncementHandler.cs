using AutoMapper;
using HRAnnouncements.Modules.Announcements.Application.Dtos;
using HRAnnouncements.Modules.Announcements.Application.Queries.Implementations;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using MediatR;

namespace HRAnnouncements.Modules.Announcements.Application.Queries.Handlers
{
    public class GetCommentsByAnnouncementHandler : IRequestHandler<GetCommentsByAnnouncementQuery, IEnumerable<CommentDto>>
    {
        private readonly IAnnouncementRepository _repository;
        private readonly IMapper _mapper;

        public GetCommentsByAnnouncementHandler(IAnnouncementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> Handle(GetCommentsByAnnouncementQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetCommentsByAnnouncementIdAsync(request.AnnouncementId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }
    }
}
