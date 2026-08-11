namespace Suma.AdminPanel.Services.Operators;

public record OperatorSearchModel(
	int Page,
	int PageSize,
	string? Email,
	string? Username,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	public static new OperatorSearchModel All { get; } = new(default, default, default, default, default);
}

public record OperatorListItemDto(
	Guid Id,
	string Username,
	string Email,
	bool IsEnabled,
	bool IsEditable,
	string[] Roles);

public record OperatorDto(
	Guid Id,
	string Username,
	string Email,
	bool IsEnabled,
	string[] Roles,
	bool IsEditable);

public record AddOperatorRequest(
	string Username,
	string Email,
	string Password,
	bool IsEnabled);

public record UpdateOperatorRequest(
	string Username,
	string Email,
	bool IsEnabled);

public record ResetOperatorPasswordRequest(
	Guid OperatorId,
	string NewPassword);
