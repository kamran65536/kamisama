using KamiSama.Extensions.Paging;

namespace KamiSama.Modules.Identity.Services.Roles;

public record RoleSearchModel(int Page, int PageSize, string? Name, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
{
	public static new readonly RoleSearchModel All = new(0, 0, default, default);
}

public record RoleDto(Guid Id, string Name);
public record AddRoleRequest(string Name);
public record UpdateRoleRequest(string Name);
