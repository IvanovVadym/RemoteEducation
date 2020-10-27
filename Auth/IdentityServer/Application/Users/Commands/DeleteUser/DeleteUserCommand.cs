using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RE.Application.Library.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand: IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
