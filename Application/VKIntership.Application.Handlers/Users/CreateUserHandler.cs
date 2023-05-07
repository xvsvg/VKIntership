using VKIntership.Application.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using VKIntership.Application.Abstractions;
using VKIntership.Domain.Core.Users;
using VKIntership.Infrastructure.Mapping.Users;
using MediatR;
using VKIntership.Domain.Common;
using static VKIntership.Application.Contracts.Users.Commands.CreateUser;

namespace VKIntership.Application.Handlers.Users;

internal class CreateUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateUserHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var userExists = await _context.Users
            .AnyAsync(x => x.Login.Equals(request.Login));

        var role = await _context.UserGroups
            .FirstOrDefaultAsync(
                x => x.Description.Equals(ApplicationUserRoles.User),
                cancellationToken);

        var status = await _context.UserStates
            .FirstOrDefaultAsync(
                x => x.Description.Equals(ApplicationUserState.Active),
                cancellationToken);

        var adminUserExists = await _context.Users
            .AnyAsync(x => x.UserGroup.Code.Equals(ApplicationUserRoles.Admin));

        if (role is null)
            throw new EntityNotFoundException("Role \"user\" does not exist");

        if (status is null)
            throw new EntityNotFoundException("Status \"active\" does not exist");

        if (adminUserExists)
            throw new InvalidOperationException("Unable to create admin, because admin already exists");

        if (userExists)
            throw new InvalidOperationException($"User with login {request.Login} already exists");

        var user = new User(
            Guid.NewGuid(),
            request.Login,
            request.Password,
            DateTime.UtcNow,
            role,
            status);

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(user.ToDto());
    }
}