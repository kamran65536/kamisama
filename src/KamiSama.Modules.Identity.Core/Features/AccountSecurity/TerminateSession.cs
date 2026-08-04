namespace KamiSama.Modules.Identity.Features.AccountSecurity;

[AutoInjectScoped<ITerminateSession>]
internal class TerminateSession(IApplicationSessionRepository sessionRepository) : ITerminateSession
{
	public Task TerminateAsync(Guid userId, string sessionId, CancellationToken cancellationToken)
		=> sessionRepository.RevokeBySessionKeyAsync(userId, sessionId, cancellationToken);
}
