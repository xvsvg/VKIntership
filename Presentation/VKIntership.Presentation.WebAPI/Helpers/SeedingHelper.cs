using MediatR;
using VKIntership.Application.Contracts.UserRoles.Commands;
using VKIntership.Application.Contracts.UserStatus.Commands;

namespace VKIntership.Presentation.WebAPI.Helpers;

internal static class SeedingHelper
{
    internal static async Task SeedUserGroups(IServiceProvider provider)
    {
        IMediator mediator = provider.GetRequiredService<IMediator>();
        ILogger<Program> logger = provider.GetRequiredService<ILogger<Program>>();

        try
        {
            await mediator.Send(new CreateUserRoles.Command());
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex.Message);
        }
    }

    internal static async Task SeedUserStates(IServiceProvider provider)
    {
        IMediator mediator = provider.GetRequiredService<IMediator>();
        ILogger<Program> logger = provider.GetRequiredService<ILogger<Program>>();

        try
        {
            await mediator.Send(new CreateUserStatuses.Command());
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex.Message);
        }
    }

}