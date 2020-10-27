using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Groups.Queries
{
    public class GetAllGroupsQuery: IRequest<IList<GroupDto>>
    {
    }

    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, IList<GroupDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllGroupsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<GroupDto>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Groups
                .ProjectTo<GroupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
