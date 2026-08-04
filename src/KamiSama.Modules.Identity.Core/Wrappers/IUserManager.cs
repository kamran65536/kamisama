namespace KamiSama.Modules.Identity.Wrappers;
internal interface IUserManager
{
	IdentityOptions Options { get; set; }
	public string ConvertId(Guid id);
	Task<ApplicationUser?> FindByEmailAsync(string email);
	Task<ApplicationUser?> FindByIdAsync(string userId, CancellationToken cancellationToken);
	Task<ApplicationUser?> FindByNameAsync(string username);
	Task<IList<string>> GetRolesAsync(ApplicationUser user);
	Task DeleteAsync(ApplicationUser user);
	Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
	Task<IdentityResult> CreateAsync(ApplicationUser user);
	Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
	Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
	Task ConfirmEmailAsync(ApplicationUser user, string token);
	Task AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
	Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string code, string newPassword);
	Task<IdentityResult> SetTwoFactoryEnabledAsync(ApplicationUser user, bool enabled);
	Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user);
	Task<string?> GetAuthenticatorKeyAsync(ApplicationUser user);
	Task ResetAuthenticatorKeyAsync(ApplicationUser user);
	string? NormalizeEmail(string? email);
	string? NormalizeName(string? name);
	Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
	Task<IReadOnlyList<IdentityError>> ValidatePasswordAsync(ApplicationUser user, string password, CancellationToken cancellationToken);
	Task<IdentityResult> SetLockoutEnabledAsync(ApplicationUser user, bool enabled);
	Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd);
	Task<IdentityResult> UpdateSecurityStampAsync(ApplicationUser user);
	Task<IdentityResult> ResetAccessFailedCountAsync(ApplicationUser user);
	Task<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose);
	Task UpdateAsync(ApplicationUser user, CancellationToken cancellationToken);
	Task UpdateNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken);
	Task UpdateNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken);
	Task<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token);
	Task<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token);
}
