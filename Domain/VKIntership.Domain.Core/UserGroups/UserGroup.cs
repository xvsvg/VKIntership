#pragma warning disable CS8618

namespace VKIntership.Domain.Core.UserGroups;

public class UserGroup
{
    protected UserGroup()
    {
    }

    public UserGroup(Guid id, string role, string? description)
    {
        Id = id;
        Role = role;
        Description = description ?? string.Empty;
    }

    public Guid Id { get; }
    public string Role { get; }
    public string Description { get; }
}