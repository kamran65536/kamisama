using KamiSama.Chassis.HttpExceptions;
using KamiSama.Modules.Identity.DataTypes;
using KamiSama.Modules.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Users;

[AutoInjectScoped<IEnableUser>]
internal class EnableUser(
	ILogger<EnableUser> logger,
	KamiSama.Modules.Identity.Features.Users.IFindUserById identityFindUserById,
	IFindCurrentUser findCurrentUser,
	KamiSama.Modules.Identity.Features.Users.IEnableUser identityEnableUser) : IEnableUser
{
	public async Task EnableAsync(Guid userId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await identityFindUserById.FindByIdAsync(userId, cancellationToken);
			var isEditable = !identityUser.Roles.Contains(KnownRoles.SuperAdmin) && identityUser.Id != currentUser.Id;

			if (!isEditable)
				throw new NotFoundException("user.not.found", userId, nameof(userId));

			await identityEnableUser.EnableUserAsync(userId, cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to enable user {UserId}.", userId);
			throw;
		}
	}
}

