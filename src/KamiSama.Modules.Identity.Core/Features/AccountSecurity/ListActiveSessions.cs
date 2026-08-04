using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamiSama.Modules.Identity.Features.AccountSecurity;

[AutoInjectScoped<IListActiveSessions>]
internal class ListActiveSessions(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : IListActiveSessions
{
	public async Task<IReadOnlyList<ActiveSessionDto>> ListAsync(Guid userId, CancellationToken cancellationToken)
	{
		var currentSessionId = httpContextAccessor.HttpContext?.User?.FindFirstValue(SessionClaims.SessionId);
		var sessions = await sessionRepository.ListActiveByUserIdAsync(userId, cancellationToken);

		return
		[
			.. sessions.Select(session => new ActiveSessionDto(
				session.SessionKey,
				session.DeviceModel,
				session.LastConnection,
				session.IpAddress,
				string.Equals(session.SessionKey, currentSessionId, StringComparison.Ordinal)))
		];
	}
}
