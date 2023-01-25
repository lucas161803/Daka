using Daka.Application.Authentication.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Daka.WebApi.Controllers.Authentication;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}