using KamiSama.Modules.Identity.Features.Password;
using KamiSama.Modules.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Accounts;

[AutoInjectScoped<IChangePassword>]
internal class ChangePassword(
	ILogger<ChangePassword> logger,
	IFindCurrentUser findCurrentUser,
	IResetPassword resetPassword) : IChangePassword
{
	public async Task ChangeAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);

			await resetPassword.ResetPasswordAsync(
				new ResetPasswordRequest(currentUser.Email ?? currentUser.Username, request.NewPassword),
				cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to change the current user password.");
			throw;
		}
	}
}
