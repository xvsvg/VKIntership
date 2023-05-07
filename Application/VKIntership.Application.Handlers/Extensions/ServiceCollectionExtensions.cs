using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VKIntership.Application.Contracts.Tools;

namespace VKIntership.Application.Handlers.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection collection, IConfiguration configuration)
    {
        IConfigurationSection paginationSection = configuration.GetSection("Pagination");
        collection.Configure<PaginationConfiguration>(x => paginationSection.Bind(x));

        collection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(IAssemblyMarker)));

        return collection;
    }
}