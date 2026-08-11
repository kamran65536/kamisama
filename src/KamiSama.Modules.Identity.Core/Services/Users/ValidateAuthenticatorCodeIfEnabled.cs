namespace KamiSama.Modules.Identity.Services.Users;

internal interface IValidateAuthenticatorCodeIfEnabled
{
	Task ValidateAsync(ApplicationUser user, string? twoFactorCode);
}

[AutoInjectScoped<IValidateAuthenticatorCodeIfEnabled>]
internal class ValidateAuthenticatorCodeIfEnabled(IUserManager userManager) : IValidateAuthenticatorCodeIfEnabled
{
	public async Task ValidateAsync(ApplicationUser user, string? twoFactorCode)
	{
		var isTwoFactorEnabled = await userManager.GetTwoFactorEnabledAsync(user);
		if (!isTwoFactorEnabled)
			return;

		var normalizedCode = twoFactorCode?
			.Replace(" ", string.Empty)
			.Replace("-", string.Empty);
		if (string.IsNullOrWhiteSpace(normalizedCode))
			throw new UnAuthorizedException();

		var isTokenValid = await userManager.VerifyTwoFactorTokenAsync(
			user,
			userManager.Options.Tokens.AuthenticatorTokenProvider,
			normalizedCode);
		if (!isTokenValid)
			throw new UnAuthorizedException();
	}
}
