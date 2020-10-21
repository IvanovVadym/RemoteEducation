using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Schedules.Commands.CreateSchedule
{
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            RuleFor(v => v.DateTime)
                .NotEmpty().WithMessage("DateTime is required.")
                .Must(dateTime => dateTime > DateTime.Now)
                .WithMessage("DateTime greater then current time");
        }
    }
}
