using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using RE.Application.Library.Exceptions;

namespace Application.Schedules.Commands.UpdateSchedule
{
    public class UpdateScheduleCommand: IRequest
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IReMemoryCache<Schedule> _memoryCache;

        public UpdateScheduleCommandHandler(IApplicationDbContext context, IReMemoryCache<Schedule> memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        public async Task<Unit> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = _memoryCache.GetValue(request.Id) 
                         ?? await _context.Schedules.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Schedule), request.Id);
            }

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


            entity.SubjectId = request.SubjectId;
            entity.TeacherId = request.TeacherId;
            entity.GroupId = request.GroupId;
            entity.DateTime = request.DateTime;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
