using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using KamiSama.Modules.Identity.Features.AccountSecurity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<ITokenService>]
internal class TokenService(
	IUserManager userManager,
	IApplicationSessionManager sessionManager,
	IOptions<JwtOptions> options) : ITokenService
{
	public async Task<string> GenerateAccessTokenAsync(Guid userId, CancellationToken cancellationToken)
		=> (await GenerateTokenPairAsync(userId, cancellationToken)).AccessToken;

	public async Task<string> GenerateAccessTokenAsync(Guid userId, string sessionKey, CancellationToken cancellationToken)
		=> (await GenerateTokenPairAsync(userId, sessionKey, cancellationToken)).AccessToken;

	public async Task<TokenPairDto> GenerateTokenPairAsync(Guid userId, CancellationToken cancellationToken)
	{
		var session = await sessionManager.CreateAsync(userId, cancellationToken);
		return await GenerateTokenPairAsync(userId, session.SessionKey, cancellationToken);
	}

	public async Task<TokenPairDto> GenerateTokenPairAsync(Guid userId, string sessionKey, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(userId.ToString(), cancellationToken)
				   ?? throw new NotFoundException<ApplicationUser>(userId);
		var roles = await userManager.GetRolesAsync(user);

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Key));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var claims = new List<Claim>
		{
			new(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new(ClaimTypes.Email, user.Email ?? ""),
			new(ClaimTypes.Name, user.UserName ?? ""),
			new("isEnabled", user.EmailConfirmed.ToString().ToLowerInvariant()),
			new(SessionClaims.SessionId, sessionKey)
		};

		claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

		var accessToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
			issuer: options.Value.Issuer,
			audience: options.Value.Audience,
			claims: claims,
			expires: DateTime.UtcNow + options.Value.AccessTokenExpiration,
			signingCredentials: creds));
		var refreshToken = await GenerateRefreshTokenAsync(user.Id, sessionKey, cancellationToken);

		return new TokenPairDto(accessToken, refreshToken);
	}

	public async Task<string> GenerateRefreshTokenAsync(Guid userId, string sessionKey, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(userId.ToString(), cancellationToken)
				   ?? throw new NotFoundException<ApplicationUser>(userId);

		return await userManager.GenerateUserTokenAsync(
			user,
			TokenOptions.DefaultProvider,
			RefreshTokenPurposeFactory.Build(sessionKey));
	}
}
