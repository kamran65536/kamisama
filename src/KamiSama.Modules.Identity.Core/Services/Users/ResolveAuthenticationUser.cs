namespace KamiSama.Modules.Identity.Services.Users;

internal interface IResolveAuthenticationUser
{
	Task<ApplicationUser> ResolveAsync(Guid? userId, string? login, CancellationToken cancellationToken);
}

[AutoInjectScoped<IResolveAuthenticationUser>]
internal class ResolveAuthenticationUser(IUserManager userManager) : IResolveAuthenticationUser
{
	public async Task<ApplicationUser> ResolveAsync(Guid? userId, string? login, CancellationToken cancellationToken)
	{
		if (userId is not null)
			return await userManager.FindByIdAsync(userManager.ConvertId(userId.Value), cancellationToken)
				?? throw new UnAuthorizedException();

		if (string.IsNullOrWhiteSpace(login))
			throw new BadRequestException("Login is required.");

		return await userManager.FindByNameAsync(login)
			?? await userManager.FindByEmailAsync(login)
			?? throw new UnAuthorizedException();
	}
}
