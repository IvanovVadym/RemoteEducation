﻿using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using RE.Application.Library.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Groups.FindAsync(request.GroupId);

            if (group == null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            var entity = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserId = request.UserId,
                GroupId = request.GroupId
            };

            await _context.Students.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
