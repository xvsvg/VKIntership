using VKIntership.Application.DataAccess.Abstractions;
using VKIntership.Domain.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using MediatR;
using VKIntership.Application.Abstractions;
using static VKIntership.Application.Contracts.UserStatus.Commands.CreateUserStatuses;

namespace VKIntership.Application.Handlers.UserStatuses;

internal class CreateUserStatusesHandler : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;

    public CreateUserStatusesHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        var hasNoStatuses = await _context.UserStates.AnyAsync(cancellationToken);

        if (hasNoStatuses)
            throw new InvalidOperationException("Statuses are already created");

        var statuses = new List<UserState>
        {
            new UserState(Guid.NewGuid(), ApplicationUserState.Active, string.Empty),
            new UserState(Guid.NewGuid(), ApplicationUserState.Blocked, string.Empty)
        };

        await _context.UserStates.AddRangeAsync(statuses, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}