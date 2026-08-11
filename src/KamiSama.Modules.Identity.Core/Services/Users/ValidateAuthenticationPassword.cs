namespace KamiSama.Modules.Identity.Services.Users;

internal interface IValidateAuthenticationPassword
{
	Task ValidateAsync(ApplicationUser user, string password);
}

[AutoInjectScoped<IValidateAuthenticationPassword>]
internal class ValidateAuthenticationPassword(IUserManager userManager) : IValidateAuthenticationPassword
{
	public async Task ValidateAsync(ApplicationUser user, string password)
	{
		if (!await userManager.CheckPasswordAsync(user, password))
			throw new UnAuthorizedException();
	}
}
