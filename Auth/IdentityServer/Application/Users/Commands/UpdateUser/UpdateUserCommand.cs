using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using RE.Application.Library.Exceptions;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand: IRequest
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.UserName = request.UserName;
            entity.Email = request.Email;
            entity.Password = request.Password;
            entity.Role = request.Role;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
