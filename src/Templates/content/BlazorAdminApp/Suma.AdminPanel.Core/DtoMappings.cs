using KamiSama.Modules.Identity.DataTypes;
using KamiSama.Modules.Localization.Features;
using Suma.AdminPanel.Services.Localization;
//#if (OperatorManagement)
using Suma.AdminPanel.Services.Operators;
//#endif
//#if (UserManagement)
using Suma.AdminPanel.Services.Users;
//#endif

internal static partial class DtoMappings
{
	public static BizCultureInfoDto ToBizDto(this CultureInfoDto dto)
		=> new(
			dto.DisplayName,
			dto.RepresentedFlag,
			dto.Culture);
	//#if (OperatorManagement)
	public static OperatorListItemDto ToOperatorListItemDto(this KamiSama.Modules.Identity.Features.Users.UserDto dto, Guid currentUserId)
	{
		var isEditable = !dto.Roles.Contains(KnownRoles.SuperAdmin) && dto.Id != currentUserId;

		return new OperatorListItemDto(
			dto.Id,
			dto.Username,
			dto.Email,
			dto.IsEnabled,
			isEditable,
			dto.Roles);
	}

	public static OperatorDto ToOperatorDto(this KamiSama.Modules.Identity.Features.Users.UserDto dto, Guid currentUserId)
	{
		var isEditable = !dto.Roles.Contains(KnownRoles.SuperAdmin) && dto.Id != currentUserId;

	return new OperatorDto(
			dto.Id,
			dto.Username,
			dto.Email,
			dto.IsEnabled,
			dto.Roles,
			isEditable);
	}
	//#endif

	//#if (UserManagement)
	public static UserListItemDto ToUserListItemDto(this KamiSama.Modules.Identity.Features.Users.UserDto dto, Guid currentUserId)
	{
		var isEditable = !dto.Roles.Contains(KnownRoles.SuperAdmin) && dto.Id != currentUserId;

		return new UserListItemDto(
			dto.Id,
			dto.Username,
			dto.Email,
			dto.IsEnabled,
			isEditable,
			dto.Roles);
	}

	public static UserDto ToUserDto(this KamiSama.Modules.Identity.Features.Users.UserDto dto, Guid currentUserId)
	{
		var isEditable = !dto.Roles.Contains(KnownRoles.SuperAdmin) && dto.Id != currentUserId;

		return new UserDto(
			dto.Id,
			dto.Username,
			dto.Email,
			dto.IsEnabled,
			dto.Roles,
			isEditable);
	}
	//#endif
}
