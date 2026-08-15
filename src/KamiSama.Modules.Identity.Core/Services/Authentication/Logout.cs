using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamiSama.Modules.Identity.Services.Authentication;

[AutoInjectScoped<ILogout>]
internal class Logout(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : ILogout
{
	public Task LogoutAsync(CancellationToken cancellationToken)
	{
		var principal = httpContextAccessor.HttpContext?.User ?? throw new UnAuthorizedException();
		var userIdValue = principal.FindFirstValue(ClaimTypes.NameIdentifier);
		var sessionKey = principal.FindFirstValue(Services.AccountSecurity.SessionClaims.SessionId);

		if (!Guid.TryParse(userIdValue, out var userId) || string.IsNullOrWhiteSpace(sessionKey))
			throw new UnAuthorizedException();

		return sessionRepository.RevokeBySessionKeyAsync(userId, sessionKey, cancellationToken);
	}
}
