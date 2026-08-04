using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace KamiSama.Modules.Identity.Features.AccountSecurity;

[AutoInjectScoped<ApplicationSessionJwtBearerEvents>]
internal class ApplicationSessionJwtBearerEvents(
	IApplicationSessionManager sessionManager) : JwtBearerEvents
{
	public override async Task TokenValidated(TokenValidatedContext context)
	{
		try
		{
			await sessionManager.ValidateAsync(context.Principal!, context.HttpContext.RequestAborted);
		}
		catch (HttpExceptionBase)
		{
			context.Fail("Session is invalid.");
		}
	}
}
