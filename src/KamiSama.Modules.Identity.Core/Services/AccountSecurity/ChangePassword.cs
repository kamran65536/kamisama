using KamiSama.Modules.Identity.Services.Password;
using KamiSama.Modules.Identity.Services.Users;

namespace KamiSama.Modules.Identity.Services.AccountSecurity;

[AutoInjectScoped<IChangePassword>]
internal class ChangePassword(
	IAuthenticateUser authenticateUser,
	IResetPassword resetPassword) : IChangePassword
{
	public async Task ChangeAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
	{
		var userDto = await authenticateUser.AuthenticateAsync(
			new AuthenticateUserRequest(request.UserId, request.Username, request.Email, request.CurrentPassword),
			cancellationToken);

		await resetPassword.ResetPasswordAsync(
			new ResetPasswordRequest(userDto.Email ?? userDto.Username, request.NewPassword),
			cancellationToken);
	}
}
