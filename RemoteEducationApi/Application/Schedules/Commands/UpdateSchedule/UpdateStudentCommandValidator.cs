using System;
using FluentValidation;

namespace Application.Schedules.Commands.UpdateSchedule
{
    public class UpdateScheduleCommandValidator : AbstractValidator<UpdateScheduleCommand>
    {
        public UpdateScheduleCommandValidator()
        {
            RuleFor(v => v.DateTime)
                .NotEmpty().WithMessage("DateTime is required.")
                .Must(dateTime => dateTime > DateTime.Now);
        }
    }
}
