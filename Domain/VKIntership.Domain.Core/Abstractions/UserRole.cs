#pragma warning disable CS8618

namespace VKIntership.Domain.Core.Abstractions;

public class UserRole
{
    protected UserRole() { }

    public UserRole(Guid id, string code, string? description)
    {
        Id = id;
        Code = code;
        Description = description ?? string.Empty;
    }

    public Guid Id { get; }
    public string Code { get; }
    public string Description { get; }
}