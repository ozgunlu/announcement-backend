namespace HRAnnouncements.Modules.Announcements.Domain.Exceptions
{
    public class CommentDomainException : Exception
    {
        public CommentDomainException() { }

        public CommentDomainException(string message) : base(message) { }

        public CommentDomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
