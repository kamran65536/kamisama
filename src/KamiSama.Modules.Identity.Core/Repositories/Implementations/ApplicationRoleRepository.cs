using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Modules.Identity.Repositories.Database;
using KamiSama.Modules.Identity.Services.Roles;

namespace KamiSama.Modules.Identity.Repositories.Implementations;

[AutoInjectScoped<IApplicationRoleRepository>]
internal class ApplicationRoleRepository(ILookupNormalizer normalizer, KamiSamaIdentityDbContext context) :
	GenericRepository<ApplicationRole, RoleSearchModel, KamiSamaIdentityDbContext>(context),
	IApplicationRoleRepository
{
	protected override IQueryable<ApplicationRole> ApplySearchModel(IQueryable<ApplicationRole> query, RoleSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
		{
			var name = normalizer.NormalizeName(searchModel.Name);
			query = query.Where(x => x.NormalizedName!.Contains(name));
		}

		return searchModel.OrderBy?.ToLowerInvariant() switch
		{
			"id" => query.OrderBy(x => x.Id),
			_ => query.OrderBy(x => x.NormalizedName)
		};
	}

	public Task<ApplicationRole?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> FindAsync(x => x.Id == id, cancellationToken);

	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Id == id, cancellationToken);

	public Task<ApplicationRole?> FindByNameAsync(string name, CancellationToken cancellationToken)
	{
		var normalizedName = normalizer.NormalizeName(name);
		return FindAsync(x => x.NormalizedName == normalizedName, cancellationToken);
	}

	public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
	{
		var normalizedName = normalizer.NormalizeName(name);
		return AnyAsync(x => x.NormalizedName == normalizedName, cancellationToken);
	}
}
