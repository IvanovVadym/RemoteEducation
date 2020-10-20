using Application.Schedules.Commands.CreateSchedule;
using Application.Schedules.Commands.DeleteSchedule;
using Application.Schedules.Commands.UpdateSchedule;
using Application.Schedules.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authorization.Library.Roles;
using Microsoft.AspNetCore.Authorization;
using RE.Authorization.Library.Policies;
using RemoteEducation.Security;

namespace RemoteEducation.Controllers
{
    public class ScheduleController: ApiController
    {
        [HttpGet]
        [Authorize]
        public async Task<IList<ScheduleDto>> GetAll([FromQuery] GetAllSchedulesQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IList<ScheduleDto>> GetById([FromQuery] GetAllSchedulesQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Roles = ReRoles.Manager)]
        public async Task<ActionResult<int>> Create(CreateScheduleCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.ScheduleEditor)]
        public async Task<ActionResult> Update(int id, UpdateScheduleCommand command)
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
            await Mediator.Send(new DeleteScheduleCommand { Id = id });

            return NoContent();
        }
    }
}
