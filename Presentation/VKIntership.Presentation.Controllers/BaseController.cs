using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable CS8618

namespace VKIntership.Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    private protected IMediator _mediator;

    protected IMediator Mediator
    {
        get
        {
            IMediator? service = HttpContext.RequestServices.GetService<IMediator>();

            if (_mediator is null)
            {
                if (service is null)
                    throw new Exception();

                _mediator = service;
            }

            return _mediator;
        }
    }
}