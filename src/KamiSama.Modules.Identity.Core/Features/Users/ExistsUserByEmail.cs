namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IExistsUserByEmail>]
internal class ExistsUserByEmail(IUserManager userManager) : IExistsUserByEmail
{
	public async Task<bool> ExistsAsync(string email, CancellationToken cancellationToken)
		=> await userManager.FindByEmailAsync(email) != null;
}
