using KamiSama.Extensions.Paging;

namespace KamiSama.Modules.Identity.Services.Roles;

/// <summary>Describes paging, name filtering, and ordering requested when roles are listed.</summary>
/// <param name="Page">The one-based page number, or zero when requesting all results.</param>
/// <param name="PageSize">The maximum number of roles in a page, or zero when requesting all results.</param>
/// <param name="Name">An optional role-name filter interpreted by the implementation.</param>
/// <param name="OrderBy">An optional implementation-defined ordering expression.</param>
public record RoleSearchModel(int Page, int PageSize, string? Name, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>Gets a search model that requests all roles without filtering or explicit ordering.</summary>
	public static new readonly RoleSearchModel All = new(0, 0, default, default);
}

/// <summary>Transfers a role identifier and display name without exposing a provider entity.</summary>
/// <param name="Id">The role identifier.</param>
/// <param name="Name">The role name.</param>
public record RoleDto(Guid Id, string Name);
/// <summary>Contains the name required to create a role.</summary>
/// <param name="Name">The new role name.</param>
public record AddRoleRequest(string Name);
/// <summary>Contains the replacement name for an existing role.</summary>
/// <param name="Name">The replacement role name.</param>
public record UpdateRoleRequest(string Name);
