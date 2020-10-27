using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
    public class GetAllStudentsQuery : IRequest<IList<StudentDto>>
    {
    }

    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IList<StudentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
