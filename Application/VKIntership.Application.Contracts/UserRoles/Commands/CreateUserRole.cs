using MediatR;

namespace VKIntership.Application.Contracts.UserRoles.Commands;

internal static class CreateUserRole
{
    public record Command(string Role, string? Description) : IRequest;
}