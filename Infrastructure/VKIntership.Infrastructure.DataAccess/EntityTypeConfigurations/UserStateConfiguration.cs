using VKIntership.Domain.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKIntership.Infrastructure.DataAccess.EntityTypeConfigurations;

public class UserStateConfiguration : IEntityTypeConfiguration<UserState>
{
    public void Configure(EntityTypeBuilder<UserState> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code);
        builder.Property(x => x.Description);
    }
}