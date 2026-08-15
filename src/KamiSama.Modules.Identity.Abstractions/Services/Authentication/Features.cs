namespace KamiSama.Modules.Identity.Services.Authentication;

/// <summary>Validates login credentials, creates an application session, and issues its tokens.</summary>
public interface ILogin
{
	/// <summary>Authenticates the supplied login and returns the user and new-session tokens.</summary>
	/// <param name="request">The login identifier, password, and optional two-factor code.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The authenticated user and tokens for the newly created session.</returns>
	Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
}

/// <summary>Validates an access/refresh-token pair and issues replacement tokens for the same session.</summary>
public interface IRefreshToken
{
	/// <summary>Refreshes the supplied token pair without creating a second application session.</summary>
	/// <param name="request">The access and refresh tokens to validate.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The replacement token pair and its access-token expiration.</returns>
	Task<TokenPairDto> RefreshAsync(RefreshTokenRequest request, CancellationToken cancellationToken);
}

/// <summary>Revokes the application session represented by the current authenticated execution context.</summary>
public interface ILogout
{
	/// <summary>Revokes the current session so its cookie or access and refresh tokens can no longer authenticate.</summary>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the revocation operation.</returns>
	Task LogoutAsync(CancellationToken cancellationToken);
}

/// <summary>Revokes every application session owned by the current authenticated user.</summary>
public interface ILogoutAll
{
	/// <summary>Revokes all sessions, including the session making the request.</summary>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the revocation operation.</returns>
	Task LogoutAllAsync(CancellationToken cancellationToken);
}
