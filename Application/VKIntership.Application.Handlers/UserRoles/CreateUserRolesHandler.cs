using VKIntership.Application.Abstractions;
using VKIntership.Application.DataAccess.Abstractions;
using VKIntership.Domain.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static VKIntership.Application.Contracts.UserRoles.Commands.CreateUserRoles;

namespace VKIntership.Application.Handlers.UserRoles;

internal class CreateUserRolesHandler : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;

    public CreateUserRolesHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        var hasRoles = await _context.UserGroups.AnyAsync(cancellationToken);

        if (hasRoles)
            throw new InvalidOperationException("Roles are already created");

        var roles = new List<UserRole>
        {
            new UserRole(Guid.NewGuid(),ApplicationUserRoles.Admin, string.Empty),
            new UserRole(Guid.NewGuid(),ApplicationUserRoles.User, string.Empty),
        };

        await _context.UserGroups.AddRangeAsync(roles, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}