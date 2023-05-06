using VKIntership.Application.Dto;
using VKIntership.Domain.Core.Users;

namespace VKIntership.Infrastructure.Mapping.Users;

public static class UserMapping
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto(
            user.Id,
            user.Login,
            user.CreateDate,
            user.UserGroup.Id,
            user.UserState.Id);
    }
}