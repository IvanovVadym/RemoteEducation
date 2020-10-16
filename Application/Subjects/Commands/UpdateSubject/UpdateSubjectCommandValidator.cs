using FluentValidation;

namespace Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
    {
        public UpdateSubjectCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(30).WithMessage("FirstName must not exceed 20 characters.");
        }
    }
}
