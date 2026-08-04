using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using KamiSama.Modules.Identity.Features.AccountSecurity;

namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IFindCurrentUser>]
internal class FindCurrentUser(
	IUserManager userManager,
	IApplicationSessionManager sessionManager,
	IHttpContextAccessor httpContextAccessor) : IFindCurrentUser
{
	[ExcludeFromCodeCoverage]
	private IIdentity? GetIdentityFromContext()
	{
		return httpContextAccessor.HttpContext?.User?.Identity;
	}

	public async Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken)
	{
		var userIdentity = GetIdentityFromContext();

		if (userIdentity is not { IsAuthenticated: true })
			throw new UnAuthorizedException();

		var username = userIdentity.Name!;

		var user = await userManager.FindByNameAsync(username) ?? throw new NotFoundException<ApplicationUser>(username);
		await sessionManager.ValidateAsync(httpContextAccessor.HttpContext!.User, cancellationToken);

		var roles = await userManager.GetRolesAsync(user);

		return user.ToDto([.. roles]);
	}
}
