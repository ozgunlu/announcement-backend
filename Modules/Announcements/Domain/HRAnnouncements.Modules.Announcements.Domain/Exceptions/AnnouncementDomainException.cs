namespace HRAnnouncements.Modules.Announcements.Domain.Exceptions
{
    public class AnnouncementDomainException : Exception
    {
        public AnnouncementDomainException() { }

        public AnnouncementDomainException(string message) : base(message) { }

        public AnnouncementDomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
