using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KamiSama.Modules.Identity.Services.AccountSecurity;

[AutoInjectScoped<ApplicationSessionCookieEvents>]
internal class ApplicationSessionCookieEvents(
	IApplicationSessionManager sessionManager) : CookieAuthenticationEvents
{
	public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
	{
		try
		{
			await sessionManager.ValidateAsync(context.Principal!, context.HttpContext.RequestAborted);
		}
		catch (HttpExceptionBase)
		{
			context.RejectPrincipal();
			await context.HttpContext.SignOutAsync();
		}
	}
}
