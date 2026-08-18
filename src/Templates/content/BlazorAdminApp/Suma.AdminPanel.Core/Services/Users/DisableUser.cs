using KamiSama.Chassis.HttpExceptions;
using KamiSama.Modules.Identity.DataTypes;
using KamiSama.Modules.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Users;

[AutoInjectScoped<IDisableUser>]
internal class DisableUser(
	ILogger<DisableUser> logger,
	KamiSama.Modules.Identity.Features.Users.IFindUserById identityFindUserById,
	IFindCurrentUser findCurrentUser,
	KamiSama.Modules.Identity.Features.Users.IDisableUser identityDisableUser) : IDisableUser
{
	public async Task DisableAsync(Guid userId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await identityFindUserById.FindByIdAsync(userId, cancellationToken);
			var isEditable = !identityUser.Roles.Contains(KnownRoles.SuperAdmin) && identityUser.Id != currentUser.Id;

			if (!isEditable)
				throw new NotFoundException("user.not.found", userId, nameof(userId));

			await identityDisableUser.DisableUserAsync(userId, cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to disable user {UserId}.", userId);
			throw;
		}
	}
}

