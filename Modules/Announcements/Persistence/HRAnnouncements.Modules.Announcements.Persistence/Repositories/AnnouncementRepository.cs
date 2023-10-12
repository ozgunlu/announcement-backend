using HRAnnouncements.Modules.Announcements.Domain.Entities;
using HRAnnouncements.Modules.Announcements.Domain.Filters;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRAnnouncements.Modules.Announcements.Persistence.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly HRAnnouncementsDbContext _context;

        public AnnouncementRepository(HRAnnouncementsDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task AddAsync(Announcement announcement)
        {
            await _context.Announcements.AddAsync(announcement);
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteAsync(Guid id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
                await _context.SaveChangesAsync();
            }
        }

        // Get All
        public async Task<(IEnumerable<Announcement>, int totalRecords)> GetAllAsync(AnnouncementFilter filter)
        {
            var query = _context.Announcements.AsQueryable();

            // if there is a title filter, add to query
            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                query = query.Where(a => a.Title.Contains(filter.Title));
            }

            // Get total records before pagination
            int totalRecords = await query.CountAsync();

            // Set pagination
            var announcements = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .OrderByDescending(a => a.DatePublished)
                .ToListAsync();

            return (announcements, totalRecords);
        }

        // Get By Id
        public async Task<Announcement> GetByIdAsync(Guid id)
        {
            return await _context.Announcements.FindAsync(id);
        }        

        // Update
        public async Task UpdateAsync(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
            await _context.SaveChangesAsync();
        }

        // Get Comments By Announcement Id
        public async Task<IEnumerable<Comment>> GetCommentsByAnnouncementIdAsync(Guid announcementId)
        {
            return await _context.Comments
                    .Where(c => c.AnnouncementId == announcementId)
                    .ToListAsync();
        }

        // For Seeding Operation
        public void BulkAdd(IEnumerable<Announcement> announcements)
        {
            _context.Announcements.AddRange(announcements);
            _context.SaveChanges();
        }
    }
}
