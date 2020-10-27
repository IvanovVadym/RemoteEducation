using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using RE.Application.Library.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand: IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
    }

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            var group = await _context.Groups.FindAsync(request.GroupId);

            if (group == null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.GroupId = request.GroupId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
