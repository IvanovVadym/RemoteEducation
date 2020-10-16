using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand: IRequest<int>
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = new Group
            {
                Name = request.Name,
                Year = request.Year
            };

            await _context.Groups.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
