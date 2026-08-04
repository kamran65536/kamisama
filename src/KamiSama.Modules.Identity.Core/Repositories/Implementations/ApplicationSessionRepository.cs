using Microsoft.EntityFrameworkCore;
using KamiSama.Modules.Identity.Repositories.Database;

namespace KamiSama.Modules.Identity.Repositories.Implementations;

[AutoInjectScoped<IApplicationSessionRepository>]
internal class ApplicationSessionRepository(KamiSamaIdentityDbContext context) : IApplicationSessionRepository
{
	public async Task AddAsync(ApplicationSession session, CancellationToken cancellationToken)
	{
		await context.ApplicationSessions.AddAsync(session, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}

	public Task<ApplicationSession?> FindActiveBySessionKeyAsync(string sessionKey, CancellationToken cancellationToken)
		=> context.ApplicationSessions
			.FirstOrDefaultAsync(x => x.SessionKey == sessionKey && !x.IsRevoked, cancellationToken);

	public async Task<IReadOnlyList<ApplicationSession>> ListActiveByUserIdAsync(Guid userId, CancellationToken cancellationToken)
		=> await context.ApplicationSessions
			.Where(x => x.UserId == userId && !x.IsRevoked)
			.OrderByDescending(x => x.LastConnection)
			.ToListAsync(cancellationToken);

	public async Task RevokeAsync(ApplicationSession session, CancellationToken cancellationToken)
	{
		session.IsRevoked = true;
		session.RevokedAt = DateTime.UtcNow;
		session.LastConnection = DateTime.UtcNow;

		context.ApplicationSessions.Update(session);
		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task RevokeAllExceptAsync(Guid userId, string currentSessionKey, CancellationToken cancellationToken)
	{
		var utcNow = DateTime.UtcNow;
		var sessions = await context.ApplicationSessions
			.Where(x => x.UserId == userId && !x.IsRevoked && x.SessionKey != currentSessionKey)
			.ToListAsync(cancellationToken);

		foreach (var session in sessions)
		{
			session.IsRevoked = true;
			session.RevokedAt = utcNow;
			session.LastConnection = utcNow;
		}

		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task RevokeBySessionKeyAsync(Guid userId, string sessionKey, CancellationToken cancellationToken)
	{
		var session = await context.ApplicationSessions
			.FirstOrDefaultAsync(x => x.UserId == userId && x.SessionKey == sessionKey && !x.IsRevoked, cancellationToken) ?? throw new NotFoundException<ApplicationSession>(sessionKey, nameof(sessionKey));

		await RevokeAsync(session, cancellationToken);
	}

	public async Task TouchAsync(ApplicationSession session, DateTime utcNow, CancellationToken cancellationToken)
	{
		session.LastConnection = utcNow;
		context.ApplicationSessions.Update(session);
		await context.SaveChangesAsync(cancellationToken);
	}
}
