
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StarTechApps.API.Controllers.Common;

[ApiController]
[Route("api/v{version:apiVersion}/")] //enable after adding version
//[Route("api/[controller]/[action]")]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator _mediatr => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}

