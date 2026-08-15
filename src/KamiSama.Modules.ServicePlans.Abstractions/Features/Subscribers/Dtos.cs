namespace KamiSama.Modules.ServicePlans.Features.Subscribers;

/// <summary>
/// Carries paging, filtering, and ordering criteria for subscriber listing.
/// </summary>
/// <param name="Page">The one-based page number, or the paging convention accepted by the implementation.</param>
/// <param name="PageSize">The maximum number of subscribers to return.</param>
/// <param name="ExternalUserId">The optional externally managed user identifier filter.</param>
/// <param name="IsEnabled">The optional enabled-state filter.</param>
/// <param name="OrderBy">The optional implementation-defined ordering token.</param>
public record SubscriberSearchModel(int Page, int PageSize, Guid? ExternalUserId, bool? IsEnabled, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets or sets the shared search model requesting all subscribers without filters.
	/// </summary>
	/// <value>A mutable all-records search model; replacing it affects every caller that reads this property.</value>
	public static new SubscriberSearchModel All { get; set; } = new(default, default, default, default, default);
}

/// <summary>
/// Returns a subscriber linked to an externally managed user.
/// </summary>
/// <param name="Id">The subscriber identifier.</param>
/// <param name="ExternalUserId">The externally managed user identifier.</param>
/// <param name="IsEnabled">Whether the subscriber is enabled.</param>
/// <param name="CreatedAt">The creation timestamp.</param>
/// <param name="UpdatedAt">The last update timestamp.</param>
public record SubscriberDto(Guid Id, Guid ExternalUserId, bool IsEnabled, DateTime CreatedAt, DateTime UpdatedAt);
/// <summary>
/// Carries caller-supplied values for creating a subscriber.
/// </summary>
/// <param name="ExternalUserId">The externally managed user identifier.</param>
/// <param name="IsEnabled">Whether the new subscriber is enabled.</param>
public record AddSubscriberRequest(Guid ExternalUserId, bool IsEnabled);
/// <summary>
/// Carries replacement values for an existing subscriber.
/// </summary>
/// <param name="ExternalUserId">The replacement externally managed user identifier.</param>
/// <param name="IsEnabled">Whether the subscriber is enabled.</param>
public record UpdateSubscriberRequest(Guid ExternalUserId, bool IsEnabled);
