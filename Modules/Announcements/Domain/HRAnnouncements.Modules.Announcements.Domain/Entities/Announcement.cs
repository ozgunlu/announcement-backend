using HRAnnouncements.Modules.Announcements.Domain.Exceptions;

namespace HRAnnouncements.Modules.Announcements.Domain.Entities
{
    public class Announcement
    {
        // Properties
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public int Likes { get; private set; } = 0;
        public DateTime DatePublished { get; private set; }

        // Protected Constructor to prevent unwanted instantiations outside this class.
        protected Announcement() { }

        // Factory Method
        public static Announcement Create(
            string title, 
            string content)
        {
            var announcement = new Announcement
            {
                Id = Guid.NewGuid(),
                DatePublished = DateTime.UtcNow
            };

            announcement.ChangeTitle(title);
            announcement.ChangeContent(content);

            return announcement;            
        }

        /// <summary>
        /// Sets announcement item title
        /// </summary>
        /// <param name="title">The title to be changed.</param>
        /// <exception cref="AnnouncementDomainException"></exception>
        public void ChangeTitle(string title) {
            if (string.IsNullOrEmpty(title))
                throw new AnnouncementDomainException("Title cannot be null or empty.");

            Title = title;
        }

        /// <summary>
        /// Sets announcement item content
        /// </summary>
        /// <param name="content">The content to be changed.</param>
        /// <exception cref="AnnouncementDomainException"></exception>
        public void ChangeContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new AnnouncementDomainException("Content cannot be null or empty.");

            Content = content;
        }

        // Add methods to handle likes
        public void AddLike()
        {
            Likes++;
        }
    }
}
