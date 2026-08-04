using KamiSama.Modules.Identity.DataTypes;
using KamiSama.Modules.Identity.Features.Users;
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Modules.Identity.Repositories.Database;

namespace KamiSama.Modules.Identity.Repositories.Implementations;

[AutoInjectScoped<IApplicationUserRepository>]
internal class ApplicationUserRepository(IUserManager userManager, KamiSamaIdentityDbContext context) :
	GenericRepository<ApplicationUser, UserSearchModel, KamiSamaIdentityDbContext>(context),
	IApplicationUserRepository
{
	protected override IQueryable<ApplicationUser> ApplySearchModel(IQueryable<ApplicationUser> query, UserSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.UsernameOrEmail))
		{
			var email = userManager.NormalizeEmail(searchModel.UsernameOrEmail)!;
			var username = userManager.NormalizeName(searchModel.UsernameOrEmail)!;

			query = query.Where(x =>
				x.NormalizedEmail!.Contains(email) ||
				x.NormalizedUserName!.Contains(username));
		}
		if (!string.IsNullOrWhiteSpace(searchModel.UsernameOrEmail))
		{
			var userName = userManager.NormalizeName(searchModel.UsernameOrEmail);
			query = query.Where(x => x.NormalizedUserName == userName);
		}

		return query;
	}

	public Task<ApplicationUser?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);

	public Task<ApplicationUser?> FindByEmailAsync(string email, CancellationToken cancellationToken)
		=> userManager.FindByEmailAsync(email).WaitAsync(cancellationToken);
}