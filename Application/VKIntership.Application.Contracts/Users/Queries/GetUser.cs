using VKIntership.Application.Dto;
using MediatR;

namespace VKIntership.Application.Contracts.Users.Queries;

public static class GetUser
{
    public record Query(Guid Id) : IRequest<Response>;

    public record Response(UserDto User);
}