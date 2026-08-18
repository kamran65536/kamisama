using KamiSama.Chassis.HttpExceptions;
using KamiSama.Modules.Identity.DataTypes;
using KamiSama.Modules.Identity.Features.Password;
using KamiSama.Modules.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Operators;

[AutoInjectScoped<IResetOperatorPassword>]
internal class ResetOperatorPassword(
	ILogger<ResetOperatorPassword> logger,
	IFindUserById findUserById,
	IFindCurrentUser findCurrentUser,
	IResetPassword resetPassword) : IResetOperatorPassword
{
	public async Task ResetPasswordAsync(ResetOperatorPasswordRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await findUserById.FindByIdAsync(request.OperatorId, cancellationToken);
			var isEditable = !identityUser.Roles.Contains(KnownRoles.SuperAdmin) && identityUser.Id != currentUser.Id;

			if (!isEditable)
				throw new NotFoundException("operator.not.found", request.OperatorId, nameof(request.OperatorId));

			await resetPassword.ResetPasswordAsync(
				new ResetPasswordRequest(identityUser.Email ?? identityUser.Username, request.NewPassword),
				cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to reset the password for operator {OperatorId}.", request.OperatorId);
			throw;
		}
	}
}
