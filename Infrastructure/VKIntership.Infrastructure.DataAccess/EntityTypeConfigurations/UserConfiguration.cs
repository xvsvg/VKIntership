using VKIntership.Domain.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKIntership.Infrastructure.DataAccess.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Login);
        builder.Property(x => x.Password);
        builder.Property(x => x.CreateDate);
        builder.Navigation(x => x.UserState);
        builder.Navigation(x => x.UserGroup);
    }
}