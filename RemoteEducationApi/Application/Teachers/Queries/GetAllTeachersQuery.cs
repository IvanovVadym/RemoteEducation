using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Teachers.Queries
{
    public class GetAllTeachersQuery : IRequest<IList<TeacherDto>>
    {
    }

    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, IList<TeacherDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTeachersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<TeacherDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Teachers
                .ProjectTo<TeacherDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
