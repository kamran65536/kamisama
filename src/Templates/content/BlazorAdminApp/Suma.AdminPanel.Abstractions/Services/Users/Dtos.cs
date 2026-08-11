namespace Suma.AdminPanel.Services.Users;

public record UserSearchModel(
	int Page,
	int PageSize,
	string? Email,
	string? Username,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	public static new UserSearchModel All { get; } = new(default, default, default, default, default);
}

public record UserListItemDto(
	Guid Id,
	string Username,
	string Email,
	bool IsEnabled,
	bool IsEditable,
	string[] Roles);

public record UserDto(
	Guid Id,
	string Username,
	string Email,
	bool IsEnabled,
	string[] Roles,
	bool IsEditable);

public record AddUserRequest(
	string Username,
	string Email,
	string Password,
	bool IsEnabled);

public record UpdateUserRequest(
	string Username,
	string Email,
	bool IsEnabled);

public record ResetUserPasswordRequest(
	Guid UserId,
	string NewPassword);

