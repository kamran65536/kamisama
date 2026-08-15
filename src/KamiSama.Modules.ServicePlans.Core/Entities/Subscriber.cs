namespace KamiSama.Modules.ServicePlans.Entities;

/// <summary>
/// Represents a subscriber linked to an externally managed user.
/// </summary>
public class Subscriber
{
	/// <summary>
	/// Gets or sets the identifier of the subscriber.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the identifier of the corresponding external customer.
	/// </summary>
	public required Guid ExternalUserId { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the subscriber may consume computation units.
	/// </summary>
	public required bool IsEnabled { get; set; }

	/// <summary>
	/// Gets or sets the creation timestamp of the subscriber.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the last update timestamp of the subscriber.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }

	/// <summary>
	/// Gets or sets the subscriptions owned by the subscriber.
	/// </summary>
	public virtual ICollection<Subscription> Subscriptions { get; set; } = [];
}
