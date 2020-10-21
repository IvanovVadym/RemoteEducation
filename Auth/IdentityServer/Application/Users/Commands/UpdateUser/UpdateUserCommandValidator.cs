using FluentValidation;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must not has less then 6 characters.");

            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(10).WithMessage("UserName must not exceed 10 characters.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(v => v.Role)
                .NotEmpty().WithMessage("Role is required.");
        }
    }
}
