#pragma warning disable CS8618

namespace VKIntership.Domain.Core.Abstractions;

public class UserState
{
    protected UserState() { }

    public UserState(Guid id, string code, string? description)
    {
        Id = id;
        Code = code;
        Description = description ?? string.Empty;
    }

    public Guid Id { get; }
    public string Code { get; }
    public string Description { get; }
}