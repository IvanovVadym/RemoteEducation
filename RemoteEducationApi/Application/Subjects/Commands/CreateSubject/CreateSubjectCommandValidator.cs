using FluentValidation;

namespace Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(30).WithMessage("FirstName must not exceed 20 characters.");
        }
    }
}
