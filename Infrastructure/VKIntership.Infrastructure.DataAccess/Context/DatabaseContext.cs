using VKIntership.Application.DataAccess.Abstractions;
using VKIntership.Domain.Core.Abstractions;
using VKIntership.Domain.Core.Users;
using Microsoft.EntityFrameworkCore;

namespace VKIntership.Infrastructure.DataAccess.Context;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; protected init; } = null!;
    public DbSet<UserState> UserStates { get; protected init; } = null!;
    public DbSet<UserRole> UserGroups { get; protected init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}