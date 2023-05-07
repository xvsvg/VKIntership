using VKIntership.Application.DataAccess.Abstractions;
using VKIntership.Infrastructure.Mapping.Users;
using VKIntership.Application.Contracts.Tools;
using VKIntership.Application.Dto;
using VKIntership.Domain.Core.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static VKIntership.Application.Contracts.Users.Queries.GetAllUsers;

namespace VKIntership.Application.Handlers.Users;

public class GetAllUsersHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;
    private readonly PaginationConfiguration _paginationConfiguration;

    public GetAllUsersHandler(IDatabaseContext context, PaginationConfiguration paginationConfiguration)
    {
        _context = context;
        _paginationConfiguration = paginationConfiguration;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        IQueryable<User> query = _context.Users;

        var usersCount = await query.CountAsync(cancellationToken);
        var pageCount = (int)Math.Ceiling((double)usersCount / _paginationConfiguration.PageSize);

        if (request.Page >= pageCount)
            return new Response(Array.Empty<UserDto>(), pageCount);

        var users = await query
            .OrderBy(x => x.CreateDate)
            .Skip(request.Page * _paginationConfiguration.PageSize)
            .Take(_paginationConfiguration.PageSize)
            .ToListAsync(cancellationToken);

        return new Response(users.Select(x => x.ToDto()), pageCount);
    }
}