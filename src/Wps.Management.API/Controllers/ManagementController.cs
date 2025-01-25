using Microsoft.AspNetCore.Mvc;
using Wps.Management.API.Application;

namespace Wps.Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController(ManagementApplicationService managementApplicationService,
        ICommandHandler<SetWeightCommand> commandHandler) : ControllerBase
    { 
        [HttpPost]
        public async Task<IActionResult> Post(CreatePetCommand createPetCommand)
        {
            await managementApplicationService.Handle(createPetCommand);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(SetWeightCommand  command)
        {
            await commandHandler.Handle(command);
            return Ok();
        }
    }
}
