using VKIntership.Application.Dto;
using MediatR;

namespace VKIntership.Application.Contracts.Users.Queries;

public static class GetAllUsers
{
    public record Query(int Page) : IRequest<Response>;

    public record Response(IEnumerable<UserDto> Users, int PageCount);
}