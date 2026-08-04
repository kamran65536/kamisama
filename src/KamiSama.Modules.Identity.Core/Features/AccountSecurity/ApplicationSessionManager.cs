using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamiSama.Modules.Identity.Features.AccountSecurity;

[AutoInjectScoped<IApplicationSessionManager>]
internal class ApplicationSessionManager(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : IApplicationSessionManager
{
	public async Task<ApplicationSession> CreateAsync(Guid userId, CancellationToken cancellationToken)
	{
		var utcNow = DateTime.UtcNow;
		var session = new ApplicationSession
		{
			UserId = userId,
			SessionKey = Guid.NewGuid().ToString("N"),
			DeviceModel = httpContextAccessor.HttpContext?.Request.Headers.UserAgent.ToString() ?? "Unknown",
			IpAddress = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
			IsRevoked = false,
			CreatedAt = utcNow,
			LastConnection = utcNow,
			RevokedAt = null,
		};

		await sessionRepository.AddAsync(session, cancellationToken);
		return session;
	}

	public async Task<ApplicationSession> ValidateAsync(ClaimsPrincipal principal, CancellationToken cancellationToken)
	{
		var sessionKey = principal.FindFirstValue(SessionClaims.SessionId)
			?? throw new UnAuthorizedException();

		var userIdValue = principal.FindFirstValue(ClaimTypes.NameIdentifier)
			?? throw new UnAuthorizedException();

		if (!Guid.TryParse(userIdValue, out var userId))
			throw new UnAuthorizedException();

		var session = await sessionRepository.FindActiveBySessionKeyAsync(sessionKey, cancellationToken)
			?? throw new UnAuthorizedException();

		if (session.UserId != userId)
			throw new UnAuthorizedException();

		await sessionRepository.TouchAsync(session, DateTime.UtcNow, cancellationToken);
		return session;
	}
}
