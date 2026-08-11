using KamiSama.Chassis.HttpExceptions;
using Polareum.Identity.DataTypes;
using Polareum.Identity.Features.Password;
using Polareum.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Users;

[AutoInjectScoped<IResetUserPassword>]
internal class ResetUserPassword(
	ILogger<ResetUserPassword> logger,
	IFindUserById findUserById,
	IFindCurrentUser findCurrentUser,
	IResetPassword resetPassword) : IResetUserPassword
{
	public async Task ResetPasswordAsync(ResetUserPasswordRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await findUserById.FindByIdAsync(request.UserId, cancellationToken);
			var isEditable = !identityUser.Roles.Contains(KnownRoles.SuperAdmin) && identityUser.Id != currentUser.Id;

			if (!isEditable)
				throw new NotFoundException("user.not.found", request.UserId, nameof(request.UserId));

			await resetPassword.ResetPasswordAsync(
				new ResetPasswordRequest(identityUser.Email ?? identityUser.Username, request.NewPassword),
				cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to reset the password for user {UserId}.", request.UserId);
			throw;
		}
	}
}

