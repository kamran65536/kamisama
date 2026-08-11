namespace KamiSama.Modules.Identity.Services.Users;

[AutoInjectScoped<IEnable2fa>]
internal class Enable2fa(
	ILogger<Enable2fa> logger,
	IUserManager userManager) : IEnable2fa
{
	public async Task EnableAsync(Enable2faRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		var user = (await userManager.FindByIdAsync(userManager.ConvertId(request.UserId), cancellationToken)) ?? throw new NotFoundException<ApplicationUser>(request.UserId, nameof(request.UserId));

		// Strip spaces and hyphens
		var verificationCode = request
			.VerificationCode
			.Replace(" ", string.Empty)
			.Replace("-", string.Empty);

		var is2faTokenValid = await userManager.VerifyTwoFactorTokenAsync(
				user,
				userManager.Options.Tokens.AuthenticatorTokenProvider,
				verificationCode);

		if (!is2faTokenValid)
			throw new InvalidOperationHttpException("Error: Verification code is invalid.");

		await userManager.SetTwoFactoryEnabledAsync(user, true);
		logger.LogInformation("Two factor authentication for user {} with id {} is enabled.", user.UserName, request.UserId);

	}
}