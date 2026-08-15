using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamiSama.Modules.Identity.Services.Authentication;

[AutoInjectScoped<ILogoutAll>]
internal class LogoutAll(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : ILogoutAll
{
	public Task LogoutAllAsync(CancellationToken cancellationToken)
	{
		var userIdValue = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
		if (!Guid.TryParse(userIdValue, out var userId))
			throw new UnAuthorizedException();

		return sessionRepository.RevokeAllAsync(userId, cancellationToken);
	}
}
