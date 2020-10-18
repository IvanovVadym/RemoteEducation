﻿using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var entity = new Teacher
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _context.Teachers.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
