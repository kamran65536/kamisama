namespace KamiSama.Modules.Identity.Wrappers;

[AutoInjectScoped<IUserManager>]
internal class WrappedUserManager(UserManager<ApplicationUser> userManager) : IUserManager
{
	public IdentityOptions Options { get => userManager.Options; set => userManager.Options = value; }
	public string ConvertId(Guid id) => id.ToString().ToUpper();
	public Task<ApplicationUser?> FindByEmailAsync(string email)
		=> userManager.FindByEmailAsync(email);
	public Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
		=> userManager.GeneratePasswordResetTokenAsync(user);
	public Task<IList<string>> GetRolesAsync(ApplicationUser user)
		=> userManager.GetRolesAsync(user);
	public Task<ApplicationUser?> FindByNameAsync(string username)
		=> userManager.FindByNameAsync(username);
	public Task<ApplicationUser?> FindByIdAsync(string id, CancellationToken cancellationToken)
		=> userManager.FindByIdAsync(id);
	public Task DeleteAsync(ApplicationUser user)
		=> userManager.DeleteAsync(user);
	public Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
		=> userManager.CreateAsync(user, password);
	public Task<IdentityResult> CreateAsync(ApplicationUser user)
		=> userManager.CreateAsync(user);
	public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
		=> userManager.GenerateEmailConfirmationTokenAsync(user);
	public Task ConfirmEmailAsync(ApplicationUser user, string token)
		=> userManager.ConfirmEmailAsync(user, token);
	public Task AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles)
		=> userManager.AddToRolesAsync(user, roles);
	public Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string code, string newPassword)
		=> userManager.ResetPasswordAsync(user, code, newPassword);
	public Task<IdentityResult> SetTwoFactoryEnabledAsync(ApplicationUser user, bool enabled)
		=> userManager.SetTwoFactorEnabledAsync(user, enabled);
	public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
		=> userManager.GetTwoFactorEnabledAsync(user);
	public Task<string?> GetAuthenticatorKeyAsync(ApplicationUser user)
		=> userManager.GetAuthenticatorKeyAsync(user);
	public Task ResetAuthenticatorKeyAsync(ApplicationUser user)
		=> userManager.ResetAuthenticatorKeyAsync(user);
	public string? NormalizeEmail(string? email)
		=> userManager.NormalizeEmail(email);
	public string? NormalizeName(string? name)
		=> userManager.NormalizeName(name);
	public Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
		=> userManager.CheckPasswordAsync(user, password);
	public Task UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
		=> userManager.UpdateAsync(user);
	public Task UpdateNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
		=> userManager.UpdateNormalizedUserNameAsync(user);
	public Task UpdateNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
		=> userManager.UpdateNormalizedEmailAsync(user);
	public async Task<IReadOnlyList<IdentityError>> ValidatePasswordAsync(ApplicationUser user, string password, CancellationToken cancellationToken)
	{
		// Use a dictionary to avoid duplicate errors from multiple validators.
		var map = new Dictionary<string, IdentityError>(StringComparer.Ordinal);

		foreach (var validator in userManager.PasswordValidators)
		{
			var result = await validator.ValidateAsync(userManager, user, password);
			if (!result.Succeeded)
			{
				foreach (var err in result.Errors)
				{
					// Prefer first occurrence; Codes come from IdentityErrorDescriber (localized Description already set).
					if (!map.ContainsKey(err.Code ?? err.Description))
						map[err.Code ?? err.Description] = err;
				}
			}
		}
		
		return [.. map.Values];
	}

	public Task<IdentityResult> SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
		=> userManager.SetLockoutEnabledAsync(user, enabled);
	public Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd)
		=> userManager.SetLockoutEndDateAsync(user, lockoutEnd);
	public Task<IdentityResult> UpdateSecurityStampAsync(ApplicationUser user)
		=> userManager.UpdateSecurityStampAsync(user);
	public Task<IdentityResult> ResetAccessFailedCountAsync(ApplicationUser user)
		=> userManager.ResetAccessFailedCountAsync(user);
	public Task<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose)
		=> userManager.GenerateUserTokenAsync(user, tokenProvider, purpose);

	public Task<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token)
		=> userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
	public Task<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token)
		=> userManager.VerifyUserTokenAsync(user, tokenProvider, purpose, token);
}
