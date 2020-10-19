using Application.Subjects.Commands.CreateSubject;
using Application.Subjects.Commands.DeleteSubject;
using Application.Subjects.Commands.UpdateSubject;
using Application.Subjects.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authorization.Library.Roles;
using Microsoft.AspNetCore.Authorization;

namespace RemoteEducation.Controllers
{
    [Authorize(Policy = ReRoles.Manager)]
    public class SubjectController: ApiController
    {
        [HttpGet]
        public async Task<IList<SubjectDto>> GetAll([FromQuery] GetAllSubjectsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetById([FromQuery] GetSubjectByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSubjectCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSubjectCommand command)
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
            await Mediator.Send(new DeleteSubjectCommand { Id = id });

            return NoContent();
        }
    }
}
