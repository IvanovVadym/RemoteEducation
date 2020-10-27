using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using RE.Application.Library.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Schedules.Queries;
using Microsoft.EntityFrameworkCore;

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
        private readonly IApplicationCache<Schedule> _applicationCache;

        public CreateTodoItemCommandHandler(IApplicationDbContext context, IApplicationCache<Schedule> applicationCache)
        {
            _context = context;
            _applicationCache = applicationCache;
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
                GroupId = request.GroupId,
                DateTime = request.DateTime
            };
            
            await _context.Schedules.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            CacheEntity(entity, cancellationToken);

            return entity.Id;
        }

        private async void CacheEntity(Schedule entity, CancellationToken cancellationToken)
        {
           var entityWithChildren =  await _context.Schedules
                .Include(s => s.Teacher)
                .Include(s => s.Group)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(s => s.Id == entity.Id, cancellationToken: cancellationToken);

           _applicationCache.Set(entityWithChildren.Id, entityWithChildren);
        }
    }
}
