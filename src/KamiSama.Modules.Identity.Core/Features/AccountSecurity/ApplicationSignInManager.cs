using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace KamiSama.Modules.Identity.Features.AccountSecurity;

internal class ApplicationSignInManager(
	UserManager<ApplicationUser> userManager,
	IHttpContextAccessor contextAccessor,
	IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
	IOptions<IdentityOptions> optionsAccessor,
	ILogger<SignInManager<ApplicationUser>> logger,
	IAuthenticationSchemeProvider schemes,
	IUserConfirmation<ApplicationUser> confirmation,
	IApplicationSessionManager sessionManager)
	: SignInManager<ApplicationUser>(
		userManager,
		contextAccessor,
		claimsFactory,
		optionsAccessor,
		logger,
		schemes,
		confirmation)
{
	public override async Task SignInWithClaimsAsync(ApplicationUser user, AuthenticationProperties? authenticationProperties, IEnumerable<Claim> additionalClaims)
	{
		var session = await sessionManager.CreateAsync(user.Id, Context?.RequestAborted ?? CancellationToken.None);
		var claims = additionalClaims.Append(new Claim(SessionClaims.SessionId, session.SessionKey));

		await base.SignInWithClaimsAsync(user, authenticationProperties, claims);
	}
}
