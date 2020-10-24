using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using RE.Application.Library.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Groups.Queries
{
    public class GetGroupByIdQuery: IRequest<GroupDto>
    {
        public int Id { get; set; }
    }

    public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery, GroupDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGroupByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async  Task<GroupDto> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Groups.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            return _mapper.Map<GroupDto>(entity);
        }
    }
}
