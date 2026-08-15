using KamiSama.Modules.Identity.Services.Users;

namespace KamiSama.Modules.Identity.Services.Authentication;

/// <summary>Supplies one user name or email address, a password, and an optional authenticator code for login.</summary>
/// <param name="Login">The user name or email address that identifies the account.</param>
/// <param name="Password">The password to validate.</param>
/// <param name="TwoFactorCode">An optional authenticator code used when two-factor authentication is enabled.</param>
public record LoginRequest(string Login, string Password, string? TwoFactorCode = null);

/// <summary>Returns the authenticated user together with the tokens issued for the new session.</summary>
/// <param name="User">The provider-neutral authenticated user.</param>
/// <param name="Tokens">The access and refresh tokens issued for the session.</param>
public record LoginResponse(UserDto User, TokenPairDto Tokens);

/// <summary>Contains an expired or expiring access token and its paired refresh token.</summary>
/// <param name="AccessToken">The signed access token whose principal identifies the session.</param>
/// <param name="RefreshToken">The refresh token to validate for that session.</param>
public record RefreshTokenRequest(string AccessToken, string RefreshToken);

/// <summary>Groups an access token, its paired refresh token, and the access token's absolute expiration.</summary>
/// <param name="AccessToken">The signed access token.</param>
/// <param name="RefreshToken">The provider token used to refresh the session.</param>
/// <param name="AccessTokenExpiresAt">The UTC instant after which the access token is no longer valid.</param>
public record TokenPairDto(string AccessToken, string RefreshToken, DateTimeOffset AccessTokenExpiresAt);
