using AutoMapper;
using HRAnnouncements.Modules.Announcements.Application.Dtos;
using HRAnnouncements.Modules.Announcements.Domain.Entities;

namespace HRAnnouncements.Modules.Announcements.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Announcement, AnnouncementDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
