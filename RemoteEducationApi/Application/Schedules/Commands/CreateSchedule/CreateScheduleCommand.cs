using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using RE.Application.Library.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schedules.Commands.CreateSchedule
{
    public class CreateScheduleCommand : IRequest<int>
    {
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateScheduleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Groups.FindAsync(request.GroupId);

            if (group == null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            var teacher = await _context.Teachers.FindAsync(request.TeacherId);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(Teacher), request.TeacherId);
            }

            var subject = await _context.Subjects.FindAsync(request.SubjectId);

            if (subject == null)
            {
                throw new NotFoundException(nameof(Subject), request.SubjectId);
            }

            var entity = new Schedule
            {
                SubjectId = request.SubjectId,
                TeacherId = request.TeacherId,
                GroupId = request.GroupId
            };

            await _context.Schedules.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
