using HRAnnouncements.Modules.Announcements.Domain.Entities;
using HRAnnouncements.Modules.Announcements.Domain.Filters;

namespace HRAnnouncements.Modules.Announcements.Domain.Repositories;

public interface IAnnouncementRepository
{
    Task<(IEnumerable<Announcement>, int totalRecords)> GetAllAsync(AnnouncementFilter filter);
    Task<Announcement> GetByIdAsync(Guid id);
    Task AddAsync(Announcement announcement);
    Task UpdateAsync(Announcement announcement);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Comment>> GetCommentsByAnnouncementIdAsync(Guid announcementId);
    void BulkAdd(IEnumerable<Announcement> announcements);
}
