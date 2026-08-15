namespace KamiSama.Modules.PolicyEngine.Features.PolicyLists;

/// <summary>
/// Describes a page of policy-list definitions and the optional filters applied by Core.
/// </summary>
/// <param name="Page">The one-based page number, or the paging abstraction's all-items value.</param>
/// <param name="PageSize">The maximum number of definitions to return.</param>
/// <param name="Name">The optional case-insensitive exact list name.</param>
/// <param name="Type">The optional policy-list value type.</param>
/// <param name="IsEnabled">The optional enabled-state filter.</param>
/// <param name="OrderBy">The optional Core ordering token: <c>id</c>, <c>name</c>, <c>type</c>, <c>createdat</c>, or <c>updatedat</c>.</param>
public record PolicyListSearchModel(
	int Page,
	int PageSize,
	string? Name,
	PolicyListType? Type,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets or sets a shared search model that requests all policy lists without filtering.
	/// </summary>
	public static new PolicyListSearchModel All { get; set; } = new(default, default, default, default, default, default);
}

/// <summary>
/// Carries the persisted policy-list definition returned by list operations.
/// </summary>
/// <param name="Id">The persisted list identifier.</param>
/// <param name="Name">The display and duplicate-check name.</param>
/// <param name="Type">The declared type of values in the list.</param>
/// <param name="IsEnabled">Whether the list definition is enabled.</param>
/// <param name="CreatedAt">The UTC creation timestamp written by Core.</param>
/// <param name="UpdatedAt">The UTC last-update timestamp written by Core.</param>
public record PolicyListListItemDto(
	Guid Id,
	string Name,
	PolicyListType Type,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Carries the complete policy-list definition returned by create and find operations, without its items.
/// </summary>
/// <param name="Id">The persisted list identifier.</param>
/// <param name="Name">The display and duplicate-check name.</param>
/// <param name="Type">The declared type of values in the list.</param>
/// <param name="IsEnabled">Whether the list definition is enabled.</param>
/// <param name="CreatedAt">The UTC creation timestamp written by Core.</param>
/// <param name="UpdatedAt">The UTC last-update timestamp written by Core.</param>
public record PolicyListDto(
	Guid Id,
	string Name,
	PolicyListType Type,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Supplies the values stored for a new policy-list definition; no item CRUD contract is provided.
/// </summary>
/// <param name="Name">The list name, which Core checks for a case-insensitive duplicate.</param>
/// <param name="Type">The declared type of values intended for the list.</param>
/// <param name="IsEnabled">Whether the new definition is enabled.</param>
public record AddPolicyListRequest(string Name, PolicyListType Type, bool IsEnabled);

/// <summary>
/// Supplies replacement values for an existing policy-list definition; existing items are not included.
/// </summary>
/// <param name="Name">The replacement name, which Core checks against other list names.</param>
/// <param name="Type">The replacement declared list type; Core does not convert existing items.</param>
/// <param name="IsEnabled">Whether the updated definition is enabled.</param>
public record UpdatePolicyListRequest(string Name, PolicyListType Type, bool IsEnabled);
