using VKIntership.Infrastructure.DataAccess.Configuration;

namespace VKIntership.Presentation.WebAPI.Configuration;

internal class WebApiConfiguration
{
    public WebApiConfiguration(IConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        PostgresConfiguration? postgresConfiguration = configuration
            .GetSection(nameof(PostgresConfiguration))
            .Get<PostgresConfiguration>();

        PostgresConfiguration = postgresConfiguration ??
                                throw new ArgumentException(nameof(PostgresConfiguration));
    }

    public PostgresConfiguration PostgresConfiguration { get; }
}