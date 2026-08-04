using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using KamiSama.Modules.Identity.Features.AccountSecurity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IRefreshAccessToken>]
internal class RefreshAccessToken(
	IUserManager userManager,
	IApplicationSessionManager sessionManager,
	ITokenService tokenService,
	IOptions<JwtOptions> options) : IRefreshAccessToken
{
	public async Task<RefreshAccessTokenResponse> RefreshAsync(RefreshAccessTokenRequest request, CancellationToken cancellationToken)
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

		var tokenPair = await tokenService.GenerateTokenPairAsync(userId, session.SessionKey, cancellationToken);
		return new RefreshAccessTokenResponse(tokenPair.AccessToken, tokenPair.RefreshToken);
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
