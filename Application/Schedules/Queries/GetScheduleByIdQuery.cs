using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Common;
using MediatR;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

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
            var entity = await _context.Schedules.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Schedule), request.Id);
            }

            return _mapper.Map<ScheduleDto>(entity);
        }
    }
}
