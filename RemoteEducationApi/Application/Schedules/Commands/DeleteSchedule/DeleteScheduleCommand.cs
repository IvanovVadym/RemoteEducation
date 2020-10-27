﻿using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RE.Application.Library.Exceptions;

namespace Application.Schedules.Commands.DeleteSchedule
{
    public class DeleteScheduleCommand: IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteScheduleCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IApplicationCache<Schedule> _applicationCache;

        public DeleteTodoListCommandHandler(IApplicationDbContext context, IApplicationCache<Schedule> applicationCache)
        {
            _context = context;
            _applicationCache = applicationCache;
        }

        public async Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Schedules
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Schedule), request.Id);
            }

            _context.Schedules.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            _applicationCache.Remove(entity.Id);

            return Unit.Value;
        }
    }
}
