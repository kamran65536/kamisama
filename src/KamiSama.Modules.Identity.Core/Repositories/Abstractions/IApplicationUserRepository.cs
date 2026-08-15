using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Modules.Identity.Services.Users;
namespace KamiSama.Modules.Identity.Repositories.Abstractions;

/// <summary>
/// Defines EF-oriented user persistence, paging, and lookup used by the Core feature implementations.
/// Implementations determine search-field support and save behavior.
/// </summary>
public interface IApplicationUserRepository : IGenericRepository<ApplicationUser, UserSearchModel>
{
	/// <summary>Finds a user by identifier.</summary>
	/// <param name="Id">The user identifier.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The matching user, or <see langword="null"/>.</returns>
	Task<ApplicationUser?> FindByIdAsync(Guid Id, CancellationToken cancellationToken);
	/// <summary>Finds a user by email through the configured Identity user manager.</summary>
	/// <param name="email">The email address to look up.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The matching user, or <see langword="null"/>.</returns>
	Task<ApplicationUser?> FindByEmailAsync(string email, CancellationToken cancellationToken);
}
