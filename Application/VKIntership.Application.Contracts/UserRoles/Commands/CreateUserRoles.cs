using MediatR;

namespace VKIntership.Application.Contracts.UserRoles.Commands;

internal static class CreateUserRoles
{
    public record Command() : IRequest;
}