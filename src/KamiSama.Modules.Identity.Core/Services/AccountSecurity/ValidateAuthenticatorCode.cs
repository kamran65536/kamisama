namespace KamiSama.Modules.Identity.Services.AccountSecurity;

[AutoInjectScoped<IValidateAuthenticatorCode>]
internal class ValidateAuthenticatorCode(IUserManager userManager) : IValidateAuthenticatorCode
{
	public async Task ValidateAsync(ValidateAuthenticatorCodeRequest request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(userManager.ConvertId(request.UserId), cancellationToken)
			?? throw new NotFoundException<ApplicationUser>(request.UserId, nameof(request.UserId));

		var isTwoFactorEnabled = await userManager.GetTwoFactorEnabledAsync(user);
		if (!isTwoFactorEnabled)
			throw new UnAuthorizedException();

		var normalizedCode = request.AuthenticatorCode?
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
