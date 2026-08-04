namespace KamiSama.Modules.Identity.Features.Users;

internal interface IResolveAuthenticationUser
{
	Task<ApplicationUser> ResolveAsync(AuthenticateUserRequest request, CancellationToken cancellationToken);
}

[AutoInjectScoped<IResolveAuthenticationUser>]
internal class ResolveAuthenticationUser(IUserManager userManager) : IResolveAuthenticationUser
{
	public async Task<ApplicationUser> ResolveAsync(AuthenticateUserRequest request, CancellationToken cancellationToken)
	{
		if (request.UserId is not null)
			return await userManager.FindByIdAsync(userManager.ConvertId(request.UserId.Value), cancellationToken)
				?? throw new NotFoundException<ApplicationUser>(request.UserId, nameof(request.UserId));

		if (!string.IsNullOrWhiteSpace(request.Username))
			return await userManager.FindByNameAsync(request.Username)
				?? throw new NotFoundException<ApplicationUser>(request.Username, nameof(request.Username));

		if (!string.IsNullOrWhiteSpace(request.Email))
			return await userManager.FindByEmailAsync(request.Email)
				?? throw new NotFoundException<ApplicationUser>(request.Email, nameof(request.Email));

		throw new BadRequestException("At least one of UserId, Username or Email must be provided.");
	}
}
