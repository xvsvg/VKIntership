using VKIntership.Application.Dto;
using MediatR;

namespace VKIntership.Application.Contracts.Users.Commands;

internal static class CreateUser
{
    public record Command(string Login, string Password) : IRequest<Response>;

    public record Response(UserDto User);
}