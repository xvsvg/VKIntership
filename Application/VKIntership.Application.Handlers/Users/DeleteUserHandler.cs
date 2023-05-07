using VKIntership.Application.Abstractions;
using VKIntership.Application.DataAccess.Abstractions;
using VKIntership.Infrastructure.Mapping.Users;
using Microsoft.EntityFrameworkCore;
using MediatR;
using VKIntership.Domain.Common;
using static VKIntership.Application.Contracts.Users.Commands.DeleteUser;

namespace VKIntership.Application.Handlers.Users;

internal class DeleteUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public DeleteUserHandler(IDatabaseContext context)
    {
        _context = context;
    }


    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var status = await _context.UserStates
            .FirstOrDefaultAsync(
                x => x.Code.Equals(ApplicationUserState.Blocked),
                cancellationToken);

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);

        if (status is null)
            throw new EntityNotFoundException("Status \"Blocked\" does not exist");

        if (user is null)
            throw new EntityNotFoundException($"User with id {request.Id} does not exist");

        user.UserState = status;

        await _context.SaveChangesAsync(cancellationToken);

        return new Response(user.ToDto());
    }
}