using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommand: IRequest<int>
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Subject
            {
                Name = request.Name
            };

            await _context.Subjects.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
