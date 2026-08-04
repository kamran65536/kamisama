namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IAuthenticateUser>]
internal class AuthenticateUser(
	IResolveAuthenticationUser resolveAuthenticationUser,
	IValidateAuthenticationPassword validateAuthenticationPassword,
	IValidateAuthenticatorCodeIfEnabled validateAuthenticatorCodeIfEnabled,
	IUserManager userManager) : IAuthenticateUser
{
	public async Task<UserDto> AuthenticateAsync(AuthenticateUserRequest request, CancellationToken cancellationToken)
	{
		var user = await resolveAuthenticationUser.ResolveAsync(request, cancellationToken);
		var roles = await userManager.GetRolesAsync(user);
		await validateAuthenticationPassword.ValidateAsync(user, request.Password);
		await validateAuthenticatorCodeIfEnabled.ValidateAsync(user, request.TwoFactorCode);

		return user.ToDto([.. roles]);
	}
}
