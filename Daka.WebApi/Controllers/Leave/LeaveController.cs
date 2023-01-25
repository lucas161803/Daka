using Daka.Application.Leave.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Daka.WebApi.Controllers.Leave;

[ApiController]
[Route("leave")]
public class LeaveController : ApiControllerBase
{
    [HttpPost("apply")]
    public async Task<IActionResult> Apply(ApplyLeaveCommand request)
    {
        await Mediator.Send(request);
        return Ok();
    }
}