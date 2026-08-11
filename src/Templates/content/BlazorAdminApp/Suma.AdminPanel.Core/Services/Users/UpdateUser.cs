using KamiSama.Chassis.HttpExceptions;
using Polareum.Identity.DataTypes;
using Polareum.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Users;

[AutoInjectScoped<IUpdateUser>]
internal class UpdateUser(
	ILogger<UpdateUser> logger,
	Polareum.Identity.Features.Users.IFindUserById identityFindUserById,
	IFindCurrentUser findCurrentUser,
	Polareum.Identity.Features.Users.IUpdateUser identityUpdateUser,
	Polareum.Identity.Features.Users.IEnableUser identityEnableUser,
	Polareum.Identity.Features.Users.IDisableUser identityDisableUser) : IUpdateUser
{
	public async Task UpdateAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await identityFindUserById.FindByIdAsync(userId, cancellationToken);
			var isEditable = !identityUser.Roles.Contains(KnownRoles.SuperAdmin) && identityUser.Id != currentUser.Id;

			if (!isEditable)
				throw new NotFoundException("user.not.found", userId, nameof(userId));

			await identityUpdateUser.UpdateAsync(
				userId,
				new Polareum.Identity.Features.Users.UpdateUserRequest(
					request.Username,
					request.Email,
					string.Empty,
					[KnownRoles.User]),
				cancellationToken);

			if (identityUser.IsEnabled == request.IsEnabled)
				return;

			if (request.IsEnabled)
				await identityEnableUser.EnableUserAsync(userId, cancellationToken);
			else
				await identityDisableUser.DisableUserAsync(userId, cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to update user {UserId}.", userId);
			throw;
		}
	}
}

