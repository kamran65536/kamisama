namespace KamiSama.Modules.Identity.Services.Users;

internal interface IAuthenticateUser
{
	Task<UserDto> AuthenticateAsync(
		Guid? userId,
		string? login,
		string password,
		string? twoFactorCode,
		CancellationToken cancellationToken);
}

[AutoInjectScoped<IAuthenticateUser>]
internal class AuthenticateUser(
	IResolveAuthenticationUser resolveAuthenticationUser,
	IValidateAuthenticationPassword validateAuthenticationPassword,
	IValidateAuthenticatorCodeIfEnabled validateAuthenticatorCodeIfEnabled,
	IUserManager userManager) : IAuthenticateUser
{
	public async Task<UserDto> AuthenticateAsync(
		Guid? userId,
		string? login,
		string password,
		string? twoFactorCode,
		CancellationToken cancellationToken)
	{
		var user = await resolveAuthenticationUser.ResolveAsync(userId, login, cancellationToken);
		var roles = await userManager.GetRolesAsync(user);
		await validateAuthenticationPassword.ValidateAsync(user, password);
		await validateAuthenticatorCodeIfEnabled.ValidateAsync(user, twoFactorCode);

		return user.ToDto([.. roles]);
	}
}
