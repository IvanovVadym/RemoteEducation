using Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RE.IdentityServer.Interfaces;
using System.Threading.Tasks;

namespace RE.IdentityServer.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] GetUserQuery request)
        {
            IActionResult response = Unauthorized();
            var user = await _loginService.GetUser(Mediator, request);

            if (user == null) return response;

            var tokenString = _loginService.GetJwtToken(user);
            response = Ok(new
            {
                token = tokenString
            });
            return response;
        }
    }
}
