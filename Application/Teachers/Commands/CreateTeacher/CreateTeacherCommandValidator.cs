using FluentValidation;

namespace Application.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(20).WithMessage("FirstName must not exceed 20 characters.");

            RuleFor(v => v.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(20).WithMessage("LastName must not exceed 20 characters.");
        }
    }
}
