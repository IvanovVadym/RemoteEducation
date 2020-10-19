using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RE.Application.Library.Exceptions;

namespace Application.Users.Queries
{
    public class GetUserQuery: IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Where(user =>user.UserName == request.UserName
                           && user.Password == request.Password)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (entity == null || entity.IsDeleted)
            {
                throw new NotFoundException(nameof(User), request.UserName);
            }

            return _mapper.Map<UserDto>(entity);
        }
    }
}
