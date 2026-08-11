namespace KamiSama.Modules.Identity.Services.AccountSecurity;

[AutoInjectScoped<IGetAuthenticatorSecret>]
internal class GetAuthenticatorSecret(IUserManager userManager) : IGetAuthenticatorSecret
{
	public async Task<string> GetAsync(Guid userId, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(userManager.ConvertId(userId), cancellationToken)
			?? throw new NotFoundException<ApplicationUser>(userId, nameof(userId));

		var secret = await userManager.GetAuthenticatorKeyAsync(user);
		if (!string.IsNullOrWhiteSpace(secret))
			return secret;

		await userManager.ResetAuthenticatorKeyAsync(user);
		return await userManager.GetAuthenticatorKeyAsync(user)
			?? throw new InvalidOperationHttpException("Authenticator secret is not available.");
	}
}
