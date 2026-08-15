namespace KamiSama.Modules.PolicyEngine.Features.PolicyRules;

/// <summary>
/// Describes a page of policy-rule definitions and the optional filters applied by Core.
/// </summary>
/// <param name="Page">The one-based page number, or the paging abstraction's all-items value.</param>
/// <param name="PageSize">The maximum number of definitions to return.</param>
/// <param name="Name">The optional case-insensitive exact rule name.</param>
/// <param name="IsEnabled">The optional enabled-state filter.</param>
/// <param name="OrderBy">The optional Core ordering token: <c>id</c>, <c>name</c>, <c>processorder</c>, <c>createdat</c>, or <c>updatedat</c>.</param>
public record PolicyRuleSearchModel(
	int Page,
	int PageSize,
	string? Name,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets or sets a shared search model that requests all policy rules without filtering.
	/// </summary>
	public static new PolicyRuleSearchModel All { get; set; } = new(default, default, default, default, default);
}

/// <summary>
/// Carries the policy-rule fields returned by list operations, excluding condition source.
/// </summary>
/// <param name="Id">The persisted rule identifier.</param>
/// <param name="Name">The display and duplicate-check name.</param>
/// <param name="ProcessOrder">The application-defined ordering value for future evaluation.</param>
/// <param name="IsEnabled">Whether the rule definition is enabled.</param>
/// <param name="CreatedAt">The UTC creation timestamp written by Core.</param>
/// <param name="UpdatedAt">The UTC last-update timestamp written by Core.</param>
public record PolicyRuleListItemDto(
	Guid Id,
	string Name,
	int ProcessOrder,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Carries the complete persisted policy-rule definition returned by create and find operations.
/// </summary>
/// <param name="Id">The persisted rule identifier.</param>
/// <param name="Name">The display and duplicate-check name.</param>
/// <param name="ProcessOrder">The application-defined ordering value for future evaluation.</param>
/// <param name="ConditionSource">The opaque condition text; these packages do not parse or evaluate it.</param>
/// <param name="IsEnabled">Whether the rule definition is enabled.</param>
/// <param name="CreatedAt">The UTC creation timestamp written by Core.</param>
/// <param name="UpdatedAt">The UTC last-update timestamp written by Core.</param>
public record PolicyRuleDto(
	Guid Id,
	string Name,
	int ProcessOrder,
	string ConditionSource,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Supplies the values stored for a new ordered policy-rule definition.
/// </summary>
/// <param name="Name">The rule name, which Core checks for a case-insensitive duplicate.</param>
/// <param name="ProcessOrder">The application-defined ordering value stored for future evaluation.</param>
/// <param name="ConditionSource">The opaque condition text; Core does not validate or evaluate it.</param>
/// <param name="IsEnabled">Whether the new definition is enabled.</param>
public record AddPolicyRuleRequest(string Name, int ProcessOrder, string ConditionSource, bool IsEnabled);

/// <summary>
/// Supplies replacement values for an existing ordered policy-rule definition.
/// </summary>
/// <param name="Name">The replacement name, which Core checks against other rule names.</param>
/// <param name="ProcessOrder">The replacement application-defined ordering value.</param>
/// <param name="ConditionSource">The replacement opaque condition text.</param>
/// <param name="IsEnabled">Whether the updated definition is enabled.</param>
public record UpdatePolicyRuleRequest(string Name, int ProcessOrder, string ConditionSource, bool IsEnabled);
