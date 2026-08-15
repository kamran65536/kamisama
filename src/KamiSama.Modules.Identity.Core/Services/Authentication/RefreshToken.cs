using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using KamiSama.Modules.Identity.Services.AccountSecurity;
using KamiSama.Modules.Identity.Services.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KamiSama.Modules.Identity.Services.Authentication;

[AutoInjectScoped<IRefreshToken>]
internal class RefreshToken(
	IUserManager userManager,
	IApplicationSessionManager sessionManager,
	ITokenService tokenService,
	IOptions<JwtOptions> options) : IRefreshToken
{
	public async Task<TokenPairDto> RefreshAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(request.AccessToken) || string.IsNullOrWhiteSpace(request.RefreshToken))
			throw new BadRequestException("Access token and refresh token are required.");

		var principal = GetPrincipalFromExpiredAccessToken(request.AccessToken);
		var session = await sessionManager.ValidateAsync(principal, cancellationToken);

		var userIdValue = principal.FindFirstValue(ClaimTypes.NameIdentifier)
			?? throw new UnAuthorizedException();
		if (!Guid.TryParse(userIdValue, out var userId))
			throw new UnAuthorizedException();

		var user = await userManager.FindByIdAsync(userManager.ConvertId(userId), cancellationToken)
			?? throw new UnAuthorizedException();
		var isRefreshTokenValid = await userManager.VerifyUserTokenAsync(
			user,
			TokenOptions.DefaultProvider,
			RefreshTokenPurposeFactory.Build(session.SessionKey),
			request.RefreshToken);
		if (!isRefreshTokenValid)
			throw new UnAuthorizedException();

		return await tokenService.GenerateTokenPairAsync(userId, session.SessionKey, cancellationToken);
	}

	private ClaimsPrincipal GetPrincipalFromExpiredAccessToken(string accessToken)
	{
		var tokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = false,
			ValidateIssuerSigningKey = true,
			ValidIssuer = options.Value.Issuer,
			ValidAudience = options.Value.Audience,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Key))
		};

		var handler = new JwtSecurityTokenHandler();
		try
		{
			var principal = handler.ValidateToken(accessToken, tokenValidationParameters, out var validatedToken);
			if (validatedToken is not JwtSecurityToken jwtToken ||
				!string.Equals(jwtToken.Header.Alg, SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
				throw new UnAuthorizedException();

			return principal;
		}
		catch (SecurityTokenException)
		{
			throw new UnAuthorizedException();
		}
		catch (ArgumentException)
		{
			throw new UnAuthorizedException();
		}
	}
}
