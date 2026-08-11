using Suma.AdminPanel.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Suma.AdminPanel.Server.Controllers;

/// <summary>
/// Provides account security endpoints for current admin user.
/// </summary>
[Route("api/accounts")]
[ApiController]
public class AccountsController : ControllerBase
{
	/// <summary>
	/// Changes current admin user password.
	/// </summary>
	[HttpPost("change-password")]
	public Task ChangePasswordAsync(
		[FromServices] IChangePassword service,
		[FromBody] ChangePasswordRequest request,
		CancellationToken cancellationToken)
		=> service.ChangeAsync(request, cancellationToken);
}
