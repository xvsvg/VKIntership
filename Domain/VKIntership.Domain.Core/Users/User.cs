using VKIntership.Domain.Core.Abstractions;
using VKIntership.Domain.Core.Tools;

#pragma warning disable CS8618

namespace VKIntership.Domain.Core.Users;

public class User
{
    protected User() { }

    public User(
        Guid id,
        string login,
        string password,
        DateTime createDate,
        UserRole userGroup,
        UserState userState)
    {
        Id = id;
        Login = login;
        Password = PasswordHasher.Hash(password);
        CreateDate = createDate;
        UserGroup = userGroup;
        UserState = userState;
    }

    public Guid Id { get; }
    public string Login { get; }
    public string Password { get; }
    public DateTime CreateDate { get; }
    public UserRole UserGroup { get; }
    public UserState UserState { get; set; }
}