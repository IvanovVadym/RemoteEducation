using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Common;
using MediatR;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
