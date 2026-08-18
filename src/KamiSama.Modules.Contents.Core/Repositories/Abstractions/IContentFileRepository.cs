using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Modules.Contents.Entities;
using KamiSama.Modules.Contents.Features;

namespace KamiSama.Modules.Contents.Repositories.Abstractions;

/// <summary>
/// Provides content-file persistence beyond the generic CRUD, lookup, and search operations.
/// </summary>
public interface IContentFileRepository :
	IGenericRepository<ContentFile, ContentFileSearchModel>,
	ILookupByIdRepository<ContentFile, Guid>
{
	/// <summary>
	/// Finds a content file owned by the given user with the given name.
	/// </summary>
	/// <param name="userId">The owning user identifier.</param>
	/// <param name="name">The file name to match, compared case-insensitively.</param>
	/// <param name="cancellationToken">A token that can cancel the query.</param>
	/// <returns>The matching content file, or <see langword="null"/> if none matches.</returns>
	Task<ContentFile?> FindByUserIdAndNameAsync(Guid userId, string name, CancellationToken cancellationToken);

	/// <summary>
	/// Determines whether a content file owned by the given user with the given name already exists.
	/// </summary>
	/// <param name="userId">The owning user identifier.</param>
	/// <param name="name">The file name to match, compared case-insensitively.</param>
	/// <param name="cancellationToken">A token that can cancel the query.</param>
	/// <returns><see langword="true"/> if a matching content file exists; otherwise <see langword="false"/>.</returns>
	Task<bool> ExistsByUserIdAndNameAsync(Guid userId, string name, CancellationToken cancellationToken);
}
