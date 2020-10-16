using FluentValidation;

namespace Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
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
