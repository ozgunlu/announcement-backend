using HRAnnouncements.Modules.Announcements.Domain.Exceptions;

namespace HRAnnouncements.Modules.Announcements.Domain.Entities
{
    public class Comment
    {
        // Properties
        public Guid Id { get; private set; }
        public Guid AnnouncementId { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCommented { get; private set; }

        // Protected Constructor to prevent unwanted instantiations outside this class.
        protected Comment() { }

        // Factory Method
        public static Comment Create(
            Guid announcementId, 
            string content)
        {
            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                DateCommented = DateTime.UtcNow
            };

            comment.ChangeAnnouncementId(announcementId);
            comment.ChangeContent(content);

            return comment;
        }

        /// <summary>
        /// Sets comment item announcement id 
        /// </summary>
        /// <param name="announcementId">The announcementId to be changed.</param>
        /// <exception cref="CommentDomainException"></exception>
        public void ChangeAnnouncementId(Guid announcementId)
        {
            if (announcementId == Guid.Empty)
                throw new CommentDomainException("AnnouncementId cannot be empty.");

            AnnouncementId = announcementId;
        }

        /// <summary>
        /// Sets comment item content
        /// </summary>
        /// <param name="content">The content to be changed.</param>
        /// <exception cref="CommentDomainException"></exception>
        public void ChangeContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new CommentDomainException("Content cannot be null or empty.");

            Content = content;
        }
    }
}
