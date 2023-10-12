using FluentValidation;
using HRAnnouncements.Modules.Announcements.Application.Commands.Implementations;

namespace HRAnnouncements.Modules.Announcements.Application.Validators
{
    public class CreateAnnouncementCommentValidator : AbstractValidator<CreateAnnouncementCommentCommand>
    {
        public CreateAnnouncementCommentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty.");
        }
    }
}
