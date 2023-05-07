using VKIntership.Application.DataAccess.Abstractions;
using VKIntership.Domain.Common;
using VKIntership.Infrastructure.Mapping.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static VKIntership.Application.Contracts.Users.Queries.GetUser;

namespace VKIntership.Application.Handlers.Users;

internal class GetUserHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetUserHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(
                x => x.Id.Equals(request.Id),
                cancellationToken);

        if (user is null)
            throw new EntityNotFoundException($"User with id {request.Id} does not exist");

        return new Response(user.ToDto());
    }
}