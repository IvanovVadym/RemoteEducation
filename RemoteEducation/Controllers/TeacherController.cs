using Application.Teachers.Commands.CreateTeacher;
using Application.Teachers.Commands.DeleteTeacher;
using Application.Teachers.Commands.UpdateTeacher;
using Application.Teachers.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RemoteEducation.Models;

namespace RemoteEducation.Controllers
{
    public class TeacherController: ApiController
    {
        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IList<TeacherDto>> GetAll([FromQuery] GetAllTeachersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = Policies.User)]
        public async Task<IList<TeacherDto>> GetById([FromQuery] GetAllTeachersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTeacherCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
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
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTeacherCommand { Id = id });

            return NoContent();
        }
    }
}
