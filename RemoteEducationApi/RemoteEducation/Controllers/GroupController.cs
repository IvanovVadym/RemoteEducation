using Application.Groups.Commands.CreateGroup;
using Application.Groups.Commands.DeleteGroup;
using Application.Groups.Commands.UpdateGroup;
using Application.Groups.Queries;
using Authorization.Library.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteEducation.Controllers
{
    public class GroupController: ApiController
    {
        [HttpGet]
        [Authorize]
        public async Task<IList<GroupDto>> GetAll([FromQuery] GetAllGroupsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GroupDto>> GetById([FromQuery] GetGroupByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = ReRoles.Manager)]
        public async Task<ActionResult<int>> Create(CreateGroupCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = ReRoles.Manager)]
        public async Task<ActionResult> Update(int id, UpdateGroupCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = ReRoles.Manager)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGroupCommand { Id = id });

            return NoContent();
        }
    }
}
