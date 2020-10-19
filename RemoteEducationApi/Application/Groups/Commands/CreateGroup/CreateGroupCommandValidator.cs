using FluentValidation;

namespace Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(5).WithMessage("FirstName must not exceed 20 characters.");
        }
    }
}
