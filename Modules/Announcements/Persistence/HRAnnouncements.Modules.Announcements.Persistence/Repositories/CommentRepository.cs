using HRAnnouncements.Modules.Announcements.Domain.Entities;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;

namespace HRAnnouncements.Modules.Announcements.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly HRAnnouncementsDbContext _context;

        public CommentRepository(HRAnnouncementsDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
    }
}
