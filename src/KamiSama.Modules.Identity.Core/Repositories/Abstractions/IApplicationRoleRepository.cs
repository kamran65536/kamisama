using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Modules.Identity.Services.Roles;

namespace KamiSama.Modules.Identity.Repositories.Abstractions;

public interface IApplicationRoleRepository :
	IGenericRepository<ApplicationRole, RoleSearchModel>,
	ILookupByIdRepository<ApplicationRole, Guid>,
	ILookupByNameRepository<ApplicationRole>
{
}
