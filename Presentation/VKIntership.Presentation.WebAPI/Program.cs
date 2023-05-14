using Microsoft.EntityFrameworkCore;
using VKIntership.Application.Handlers.Extensions;
using VKIntership.Infrastructure.DataAccess.Extensions;
using VKIntership.Presentation.Controllers;
using VKIntership.Presentation.WebAPI.Configuration;
using VKIntership.Presentation.WebAPI.Extensions;
using VKIntership.Presentation.WebAPI.Helpers;

namespace VKIntership.Presentation.WebAPI;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilogForAppLogs(builder.Configuration);

        var webApiConfiguration = new WebApiConfiguration(builder.Configuration);

        builder.Services.AddDatabase(o =>
            o.UseNpgsql(webApiConfiguration.PostgresConfiguration.ToConnectionString("db")));

        builder.Services.AddHandlers(builder.Configuration);

        builder.Services.AddControllers().AddApplicationPart(typeof(IControllerAssemblyMarker).Assembly);

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (IServiceScope scope = app.Services.CreateScope())
        {
            await SeedingHelper.SeedUserGroups(scope.ServiceProvider);
            await SeedingHelper.SeedUserStates(scope.ServiceProvider);
        }

        app.MapControllers();

        await app.RunAsync();
    }
}