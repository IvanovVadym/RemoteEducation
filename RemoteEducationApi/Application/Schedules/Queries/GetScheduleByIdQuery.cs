﻿using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Groups.Queries;
using Microsoft.EntityFrameworkCore;
using RE.Application.Library.Exceptions;

namespace Application.Schedules.Queries
{
    public class GetScheduleByIdQuery: IRequest<ScheduleDto>
    {
        public int Id { get; set; }
    }

    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, ScheduleDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetScheduleByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ScheduleDto> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Schedules
                .Include(s => s.Teacher)
                .Include(s => s.Group)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Schedule), request.Id);
            }

            return _mapper.Map<ScheduleDto>(entity);
        }
    }
}
