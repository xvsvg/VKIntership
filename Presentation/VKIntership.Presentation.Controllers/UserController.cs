using MediatR;
using Microsoft.AspNetCore.Mvc;
using VKIntership.Application.Contracts.Users.Commands;
using VKIntership.Application.Contracts.Users.Queries;
using VKIntership.Application.Dto;
using VKIntership.Domain.Common;

namespace VKIntership.Presentation.Controllers;

public class UserController : BaseController
{
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId:guid}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<UserDto?>> GetUser(Guid userId)
    {
        try
        {
            var query = new GetUser.Query(userId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    public async Task<ActionResult<IEnumerable<UserDto?>>> GetAllUsers([FromQuery] int? page, CancellationToken cancellationToken)
    {
        var query = new GetAllUsers.Query(page ?? 0);
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPost("/create")]
    [ProducesResponseType(201)]
    public async Task<ActionResult<UserDto>> CreateUser(
        [FromBody] string login,
        string password,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new CreateUser.Command(login, password);
            var response = await _mediator.Send(command, cancellationToken);
            await Task.Delay(5000, cancellationToken);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{userId:guid}")]
    public async Task<ActionResult<UserDto>> DeleteUser(Guid userId)
    {
        try
        {
            var command = new DeleteUser.Command(userId);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (EntityNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

}