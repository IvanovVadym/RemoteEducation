using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Common;
using MediatR;
using AutoMapper.QueryableExtensions;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Teachers.Queries
{
    public class GetTeacherByIdQuery: IRequest<TeacherDto>
    {
        public int Id { get; set; }
    }

    public class GetTeachersQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeachersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherDto> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Teachers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Teacher), request.Id);
            }

            return _mapper.Map<TeacherDto>(entity);
        }
    }
}
