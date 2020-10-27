using Application.Users.Queries;
using System.Threading.Tasks;
using MediatR;

namespace RE.IdentityServer.Interfaces
{
    public interface ILoginService
    {
        Task<UserDto> GetUser(IMediator mediator, GetUserQuery query);
        string GetJwtToken(UserDto userInfo);
    }
}
