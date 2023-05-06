using VKIntership.Domain.Core.Users;
using VKIntership.Domain.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace VKIntership.Application.DataAccess.Abstractions;

public interface IDatabaseContext
{
    DbSet<User> Users { get; }

    DbSet<UserState> UserStates { get; }

    DbSet<UserRole> UserGroups { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}