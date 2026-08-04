namespace KamiSama.Modules.Identity.Repositories.Abstractions;

internal interface IApplicationSessionRepository
{
	Task AddAsync(ApplicationSession session, CancellationToken cancellationToken);
	Task<ApplicationSession?> FindActiveBySessionKeyAsync(string sessionKey, CancellationToken cancellationToken);
	Task<IReadOnlyList<ApplicationSession>> ListActiveByUserIdAsync(Guid userId, CancellationToken cancellationToken);
	Task RevokeAsync(ApplicationSession session, CancellationToken cancellationToken);
	Task RevokeAllExceptAsync(Guid userId, string currentSessionKey, CancellationToken cancellationToken);
	Task RevokeBySessionKeyAsync(Guid userId, string sessionKey, CancellationToken cancellationToken);
	Task TouchAsync(ApplicationSession session, DateTime utcNow, CancellationToken cancellationToken);
}
