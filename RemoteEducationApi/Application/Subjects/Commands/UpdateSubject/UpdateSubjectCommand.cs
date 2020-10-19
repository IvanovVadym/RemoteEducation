﻿using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using RE.Application.Library.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommand: IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSubjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Subject), request.Id);
            }

            entity.Name = request.Name;

            await  _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
