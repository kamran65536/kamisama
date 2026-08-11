using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamiSama.Modules.Identity.Services.AccountSecurity;

[AutoInjectScoped<ITerminateAllOtherSessions>]
internal class TerminateAllOtherSessions(
	IApplicationSessionRepository sessionRepository,
	IHttpContextAccessor httpContextAccessor) : ITerminateAllOtherSessions
{
	public async Task TerminateAllOtherAsync(Guid userId, CancellationToken cancellationToken)
	{
		var currentSessionId = httpContextAccessor.HttpContext?.User?.FindFirstValue(SessionClaims.SessionId)
			?? throw new InvalidOperationHttpException("Current session id is not available.");

		await sessionRepository.RevokeAllExceptAsync(userId, currentSessionId, cancellationToken);
	}
}
