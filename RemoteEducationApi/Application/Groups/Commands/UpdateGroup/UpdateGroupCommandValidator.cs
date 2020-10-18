using FluentValidation;

namespace Application.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(5).WithMessage("FirstName must not exceed 20 characters.");
        }
    }
}
