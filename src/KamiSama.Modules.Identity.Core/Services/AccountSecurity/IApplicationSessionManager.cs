using System.Security.Claims;

namespace KamiSama.Modules.Identity.Services.AccountSecurity;

internal interface IApplicationSessionManager
{
	Task<ApplicationSession> CreateAsync(Guid userId, CancellationToken cancellationToken);
	Task<ApplicationSession> ValidateAsync(ClaimsPrincipal principal, CancellationToken cancellationToken);
}
