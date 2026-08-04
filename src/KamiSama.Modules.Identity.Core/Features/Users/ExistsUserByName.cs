namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IExistsUserByName>]
internal class ExistsUserByName(IUserManager userManager) : IExistsUserByName
{
	public async Task<bool> ExistsByNameAsync(string username, CancellationToken cancellationToken)
		=> await userManager.FindByNameAsync(username) != null;
}
