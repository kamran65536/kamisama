using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Modules.Identity.Services.Roles;

namespace KamiSama.Modules.Identity.Repositories.Abstractions;

/// <summary>
/// Combines role mutation, paging, identifier lookup, and name lookup required by the Core role features.
/// Implementations define normalization, ordering, cancellation, and immediate persistence behavior.
/// </summary>
public interface IApplicationRoleRepository :
	IGenericRepository<ApplicationRole, RoleSearchModel>,
	ILookupByIdRepository<ApplicationRole, Guid>,
	ILookupByNameRepository<ApplicationRole>
{
}
