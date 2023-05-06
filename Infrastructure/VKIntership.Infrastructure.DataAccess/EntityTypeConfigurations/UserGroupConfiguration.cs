using VKIntership.Domain.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKIntership.Infrastructure.DataAccess.EntityTypeConfigurations;

public class UserGroupConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code);
        builder.Property(x => x.Description);
    }
}