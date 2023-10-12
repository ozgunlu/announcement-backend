using HRAnnouncements.Modules.Announcements.Domain.Entities;

namespace HRAnnouncements.Modules.Announcements.Domain.Repositories;

public interface ICommentRepository
{
    Task AddAsync(Comment comment);
}
