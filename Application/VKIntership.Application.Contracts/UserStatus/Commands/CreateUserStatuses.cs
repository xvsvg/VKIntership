using MediatR;

namespace VKIntership.Application.Contracts.UserStatus.Commands;

internal static class CreateUserStatuses
{
    public record Command() : IRequest;
}