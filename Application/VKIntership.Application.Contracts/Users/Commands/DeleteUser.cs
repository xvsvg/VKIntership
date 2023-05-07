using VKIntership.Application.Dto;
using MediatR;

namespace VKIntership.Application.Contracts.Users.Commands;

public static class DeleteUser
{
    public record Command(Guid Id) : IRequest<Response>;

    public record Response(UserDto User);
}