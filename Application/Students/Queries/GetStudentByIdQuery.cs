using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
    public class GetStudentByIdQuery: IRequest<StudentDto>
    {
        public int Id { get; set; }
    }

    public class GetStudentQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            return _mapper.Map<StudentDto>(entity);
        }
    }
}
