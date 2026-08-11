using KamiSama.Modules.Identity.Services.Roles;
using KamiSama.Modules.Identity.Services.Users;
using Riok.Mapperly.Abstractions;

namespace KamiSama.Modules.Identity;

[Mapper]
public static partial class DtoMappings
{
	public static UserDto ToDto(this ApplicationUser user, string[] roles) 
		=> new (user.Id, user.UserName!, user.Email!, roles, !user.LockoutEnabled || (user.LockoutEnd == null || user.LockoutEnd <= DateTimeOffset.UtcNow));

	public static RoleDto ToDto(this ApplicationRole role)
		=> new(role.Id, role.Name!);
}
