namespace VKIntership.Application.Dto;

public record struct UserDto(
    Guid Id,
    string Login,
    DateTime CreateDate,
    Guid UserGroupId,
    Guid UserStateId);