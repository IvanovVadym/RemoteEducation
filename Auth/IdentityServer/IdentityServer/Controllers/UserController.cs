﻿using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries;
using Authorization.Library.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RE.IdentityServer.Controllers
{
    [Authorize(Roles = ReRoles.Admin)]
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<IList<UserDto>> GetAll()
        {
            return await Mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return await Mediator.Send(new GetUserByIdQuery
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}