namespace KamiSama.Modules.PolicyEngine.Features.PolicyActions;

/// <summary>
/// Describes a page of policy-action definitions and the optional filters applied by Core.
/// </summary>
/// <param name="Page">The one-based page number, or the paging abstraction's all-items value.</param>
/// <param name="PageSize">The maximum number of definitions to return.</param>
/// <param name="Name">The optional case-insensitive exact action name.</param>
/// <param name="HandlerName">The optional case-insensitive exact handler name.</param>
/// <param name="IsEnabled">The optional enabled-state filter.</param>
/// <param name="OrderBy">The optional Core ordering token: <c>id</c>, <c>name</c>, <c>handlername</c>, <c>createdat</c>, or <c>updatedat</c>.</param>
public record PolicyActionSearchModel(
	int Page,
	int PageSize,
	string? Name,
	string? HandlerName,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets or sets a shared search model that requests all policy actions without filtering.
	/// </summary>
	public static new PolicyActionSearchModel All { get; set; } = new(default, default, default, default, default, default);
}

/// <summary>
/// Carries the policy-action fields returned by list operations, excluding handler configuration source.
/// </summary>
/// <param name="Id">The persisted action identifier.</param>
/// <param name="Name">The display and duplicate-check name.</param>
/// <param name="HandlerName">The application-defined action-handler name.</param>
/// <param name="AllowsMultiple">Whether an evaluator may retain multiple resolutions of this action.</param>
/// <param name="IsEnabled">Whether the action definition is enabled.</param>
/// <param name="CreatedAt">The UTC creation timestamp written by Core.</param>
/// <param name="UpdatedAt">The UTC last-update timestamp written by Core.</param>
public record PolicyActionListItemDto(
	Guid Id,
	string Name,
	string HandlerName,
	bool AllowsMultiple,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Carries the complete persisted policy-action definition returned by create and find operations.
/// </summary>
/// <param name="Id">The persisted action identifier.</param>
/// <param name="Name">The display and duplicate-check name.</param>
/// <param name="HandlerName">The application-defined action-handler name.</param>
/// <param name="ConfigurationSource">The opaque source that a separately implemented handler may interpret.</param>
/// <param name="AllowsMultiple">Whether an evaluator may retain multiple resolutions of this action.</param>
/// <param name="IsEnabled">Whether the action definition is enabled.</param>
/// <param name="CreatedAt">The UTC creation timestamp written by Core.</param>
/// <param name="UpdatedAt">The UTC last-update timestamp written by Core.</param>
public record PolicyActionDto(
	Guid Id,
	string Name,
	string HandlerName,
	string ConfigurationSource,
	bool AllowsMultiple,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Supplies the values stored for a new reusable policy-action definition.
/// </summary>
/// <param name="Name">The action name, which Core checks for a case-insensitive duplicate.</param>
/// <param name="HandlerName">The application-defined name of a handler; Core does not resolve or invoke it.</param>
/// <param name="ConfigurationSource">The opaque configuration text stored for a future handler.</param>
/// <param name="AllowsMultiple">Whether a future evaluator may retain multiple resolutions of the action.</param>
/// <param name="IsEnabled">Whether the new definition is enabled.</param>
public record AddPolicyActionRequest(
	string Name,
	string HandlerName,
	string ConfigurationSource,
	bool AllowsMultiple,
	bool IsEnabled);

/// <summary>
/// Supplies replacement values for an existing policy-action definition.
/// </summary>
/// <param name="Name">The replacement name, which Core checks against other action names.</param>
/// <param name="HandlerName">The replacement application-defined handler name.</param>
/// <param name="ConfigurationSource">The replacement opaque handler configuration text.</param>
/// <param name="AllowsMultiple">Whether a future evaluator may retain multiple resolutions of the action.</param>
/// <param name="IsEnabled">Whether the updated definition is enabled.</param>
public record UpdatePolicyActionRequest(
	string Name,
	string HandlerName,
	string ConfigurationSource,
	bool AllowsMultiple,
	bool IsEnabled);
