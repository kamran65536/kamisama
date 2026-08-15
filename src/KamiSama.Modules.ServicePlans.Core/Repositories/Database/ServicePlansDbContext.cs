using KamiSama.Modules.ServicePlans.Entities;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.ServicePlans.Repositories.Database;

/// <summary>
/// Provides the provider-neutral tracked EF Core sets used by ServicePlans repositories.
/// A concrete PostgreSQL or SQLite context must be registered under the configured provider key.
/// </summary>
public class ServicePlansDbContext : DbContext
{
	/// <summary>
	/// Gets or sets the plan entity set.
	/// </summary>
	public virtual DbSet<Plan> Plans { get; set; }
	/// <summary>
	/// Gets or sets the offer entity set.
	/// </summary>
	public virtual DbSet<Offer> Offers { get; set; }
	/// <summary>
	/// Gets or sets the offer-country restriction entity set.
	/// </summary>
	public virtual DbSet<OfferCountry> OfferCountries { get; set; }
	/// <summary>
	/// Gets or sets the offer payment-method entity set.
	/// </summary>
	public virtual DbSet<OfferPaymentMethod> OfferPaymentMethods { get; set; }
	/// <summary>
	/// Gets or sets the subscriber entity set.
	/// </summary>
	public virtual DbSet<Subscriber> Subscribers { get; set; }
	/// <summary>
	/// Gets or sets the subscription entity set.
	/// </summary>
	public virtual DbSet<Subscription> Subscriptions { get; set; }

	/// <summary>
	/// Initializes the provider-neutral context with options typed for direct base-context construction.
	/// </summary>
	/// <param name="options">The EF Core options for this context.</param>
	public ServicePlansDbContext(DbContextOptions<ServicePlansDbContext> options) : base(options)
	{
	}

	/// <summary>
	/// Initializes the base context with options created for a derived provider context.
	/// </summary>
	/// <param name="options">The non-generic EF Core options supplied by the concrete provider context.</param>
	protected ServicePlansDbContext(DbContextOptions options) : base(options)
	{
	}
}
