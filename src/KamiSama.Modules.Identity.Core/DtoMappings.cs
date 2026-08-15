using KamiSama.Modules.Identity.Services.Roles;
using KamiSama.Modules.Identity.Services.Users;
using Riok.Mapperly.Abstractions;

namespace KamiSama.Modules.Identity;

/// <summary>Maps Identity entities to the provider-neutral DTOs exposed by the abstractions package.</summary>
[Mapper]
public static partial class DtoMappings
{
	/// <summary>Maps a user and caller-supplied role names to a <see cref="UserDto"/>.</summary>
	/// <param name="user">The Identity user to map.</param>
	/// <param name="roles">The role names already loaded for the user.</param>
	/// <returns>A user DTO whose enabled flag follows the module's lockout calculation.</returns>
	public static UserDto ToDto(this ApplicationUser user, string[] roles) 
		=> new (user.Id, user.UserName!, user.Email!, roles, !user.LockoutEnabled || (user.LockoutEnd == null || user.LockoutEnd <= DateTimeOffset.UtcNow));

	/// <summary>Maps an Identity role to a <see cref="RoleDto"/>.</summary>
	/// <param name="role">The Identity role to map.</param>
	/// <returns>The role DTO.</returns>
	public static RoleDto ToDto(this ApplicationRole role)
		=> new(role.Id, role.Name!);
}
