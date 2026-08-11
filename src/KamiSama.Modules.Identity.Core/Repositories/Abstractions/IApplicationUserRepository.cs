using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Modules.Identity.Services.Users;
namespace KamiSama.Modules.Identity.Repositories.Abstractions;

public interface IApplicationUserRepository : IGenericRepository<ApplicationUser, UserSearchModel>
{
	Task<ApplicationUser?> FindByIdAsync(Guid Id, CancellationToken cancellationToken);
	Task<ApplicationUser?> FindByEmailAsync(string email, CancellationToken cancellationToken);
}
