using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RE.Application.Library.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommand: IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Subject), request.Id);
            }

            _context.Subjects.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
