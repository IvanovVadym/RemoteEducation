using Application.Teachers.Commands.CreateTeacher;
using Application.Teachers.Commands.DeleteTeacher;
using Application.Teachers.Commands.UpdateTeacher;
using Application.Teachers.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authorization.Library.Roles;
using Microsoft.AspNetCore.Authorization;

namespace RemoteEducation.Controllers
{
    public class TeacherController: ApiController
    {
        [HttpGet]
        [Authorize]
        public async Task<IList<TeacherDto>> GetAll([FromQuery] GetAllTeachersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TeacherDto>> GetById([FromQuery] GetTeacherByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Roles = ReRoles.Manager)]
        public async Task<ActionResult<int>> Create(CreateTeacherCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = ReRoles.Manager)]
        public async Task<ActionResult> Update(int id, UpdateTeacherCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ReRoles.Manager)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTeacherCommand { Id = id });

            return NoContent();
        }
    }
}
