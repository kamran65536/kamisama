namespace KamiSama.Modules.Identity.Services.Users;

[AutoInjectScoped<IDisableUser>]
internal class DisableUser(
	ILogger<DisableUser> logger,
	IUserManager userManager) : IDisableUser
{
	public async Task DisableUserAsync(Guid userId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		var user = await userManager.FindByIdAsync(userManager.ConvertId(userId), cancellationToken) ?? throw new NotFoundException<ApplicationUser>(userId, nameof(userId));

		await userManager.SetLockoutEnabledAsync(user, true);
		await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(100));
		await userManager.UpdateSecurityStampAsync(user);
	}
}
