using MediatR;

namespace VKIntership.Application.Contracts.UserStatus.Commands;

internal static class CreateUserStatus
{
    public record Command(string Status, string? Description) : IRequest;
}