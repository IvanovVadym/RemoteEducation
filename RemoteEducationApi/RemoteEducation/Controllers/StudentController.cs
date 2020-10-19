using Application.Students.Commands.CreateStudent;
using Application.Students.Commands.DeleteStudent;
using Application.Students.Commands.UpdateStudent;
using Application.Students.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authorization.Library.Roles;
using Microsoft.AspNetCore.Authorization;

namespace RemoteEducation.Controllers
{
    public class StudentController: ApiController
    {
        [HttpGet]
        [Authorize]
        public async Task<IList<StudentDto>> GetAll([FromQuery] GetAllStudentsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IList<StudentDto>> GetById([FromQuery] GetAllStudentsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = ReRoles.Manager)]
        public async Task<ActionResult<int>> Create(CreateStudentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = ReRoles.Manager)]
        public async Task<ActionResult> Update(int id, UpdateStudentCommand command)
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
            await Mediator.Send(new DeleteStudentCommand { Id = id });

            return NoContent();
        }
    }
}
