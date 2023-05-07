using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VKIntership.Application.Contracts.Tools;

namespace VKIntership.Application.Handlers.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection collection, IConfiguration configuration)
    {
        var cfg = configuration.GetSection("Pagination").Get<PaginationConfiguration>()
                  ?? throw new ArgumentException(nameof(PaginationConfiguration));

        collection.TryAddSingleton(cfg);

        collection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(IAssemblyMarker)));

        return collection;
    }
}