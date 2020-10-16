using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schedules.Queries
{
    public class GetAllSchedulesQuery : IRequest<IList<ScheduleDto>>
    {
    }

    public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, IList<ScheduleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllSchedulesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ScheduleDto>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Schedules
                .ProjectTo<ScheduleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
