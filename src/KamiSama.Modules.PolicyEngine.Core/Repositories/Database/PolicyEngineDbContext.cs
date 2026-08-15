using KamiSama.Modules.PolicyEngine.Entities;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.PolicyEngine.Repositories.Database;

/// <summary>
/// Provides the provider-neutral EF Core unit of work used to store PolicyEngine definitions and relationships.
/// </summary>
/// <remarks>
/// A PostgreSQL or SQLite derived context must be registered for normal module resolution. The current provider
/// packages contain no migrations, so this context model alone does not provision a database schema.
/// </remarks>
public class PolicyEngineDbContext : DbContext
{
	/// <summary>
	/// Gets or sets the tracked reusable policy-action definitions.
	/// </summary>
	public virtual DbSet<PolicyAction> PolicyActions { get; set; }
	/// <summary>
	/// Gets or sets the tracked ordered policy-rule definitions.
	/// </summary>
	public virtual DbSet<PolicyRule> PolicyRules { get; set; }
	/// <summary>
	/// Gets or sets the tracked ordered assignments between rules and actions.
	/// </summary>
	public virtual DbSet<PolicyRuleAction> PolicyRuleActions { get; set; }
	/// <summary>
	/// Gets or sets the tracked typed policy-list definitions.
	/// </summary>
	public virtual DbSet<PolicyList> PolicyLists { get; set; }
	/// <summary>
	/// Gets or sets the tracked polymorphic exact and range list items.
	/// </summary>
	public virtual DbSet<PolicyListItem> PolicyListItems { get; set; }

	/// <summary>
	/// Initializes a directly configured provider-neutral context.
	/// </summary>
	/// <param name="options">The options configured specifically for <see cref="PolicyEngineDbContext"/>.</param>
	public PolicyEngineDbContext(DbContextOptions<PolicyEngineDbContext> options) : base(options)
	{
	}

	/// <summary>
	/// Initializes a derived provider context with its provider-specific options.
	/// </summary>
	/// <param name="options">The non-generic options created for the derived context.</param>
	protected PolicyEngineDbContext(DbContextOptions options) : base(options)
	{
	}
}
