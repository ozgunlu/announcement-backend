using FluentValidation;
using HRAnnouncements.Modules.Announcements.Application.Commands.Implementations;

namespace HRAnnouncements.Modules.Announcements.Application.Validators
{
    public class CreateAnnouncementValidator : AbstractValidator<CreateAnnouncementCommand>
    {
        public CreateAnnouncementValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty.");
        }
    }
}
