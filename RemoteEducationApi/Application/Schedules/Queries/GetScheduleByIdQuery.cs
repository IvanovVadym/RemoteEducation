using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly IReMemoryCache<Schedule> _memoryCache;

        public GetScheduleByIdQueryHandler(IApplicationDbContext context, IMapper mapper,
            IReMemoryCache<Schedule> memoryCache)
        {
            _context = context;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<ScheduleDto> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var cachedEntity = _memoryCache.GetValue(request.Id);

            if (cachedEntity != null) return _mapper.Map<ScheduleDto>(cachedEntity);

            var entity = await _context.Schedules.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Schedule), request.Id);
            }

            _memoryCache.SetValue(entity.Id, entity);

            return _mapper.Map<ScheduleDto>(entity);
        }
    }
}
