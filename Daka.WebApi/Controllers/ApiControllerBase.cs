using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Daka.WebApi.Controllers;

[ApiController]
public class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}