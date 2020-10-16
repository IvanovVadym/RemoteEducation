using FluentValidation;

namespace Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
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
