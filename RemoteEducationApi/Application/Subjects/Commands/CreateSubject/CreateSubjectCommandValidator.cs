using FluentValidation;

namespace Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(30).WithMessage("Name must not exceed 30 characters.");
        }
    }
}
