using VKIntership.Domain.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKIntership.Domain.Core.Abstractions;

namespace VKIntership.Infrastructure.DataAccess.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Login);
        builder.Property(x => x.Password);
        builder.Property(x => x.CreateDate);

        builder.HasOne(x => x.UserState);
        builder.HasOne(x => x.UserGroup);
    }
}