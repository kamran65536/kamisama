namespace KamiSama.Modules.Identity.Services.AccountSecurity;

/// <summary>Lists active sessions for a user; implementations define authorization and current-session detection.</summary>
public interface IListActiveSessions
{
	/// <summary>Returns active sessions for the specified user.</summary>
	/// <param name="userId">The user whose sessions are requested.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The active sessions in implementation-defined order.</returns>
	Task<IReadOnlyList<ActiveSessionDto>> ListAsync(Guid userId, CancellationToken cancellationToken);
}

/// <summary>Revokes every active session for a user except the implementation-defined current session.</summary>
public interface ITerminateAllOtherSessions
{
	/// <summary>Terminates all other sessions for the specified user.</summary>
	/// <param name="userId">The user whose other sessions are revoked.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the revocation operation.</returns>
	Task TerminateAllOtherAsync(Guid userId, CancellationToken cancellationToken);
}

/// <summary>Revokes one session belonging to a user.</summary>
public interface ITerminateSession
{
	/// <summary>Terminates the selected session.</summary>
	/// <param name="userId">The owner of the session.</param>
	/// <param name="sessionId">The public session identifier interpreted by the implementation.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the revocation operation.</returns>
	Task TerminateAsync(Guid userId, string sessionId, CancellationToken cancellationToken);
}

/// <summary>Reads or creates the authenticator secret associated with a user.</summary>
public interface IGetAuthenticatorSecret
{
	/// <summary>Returns the user's authenticator secret.</summary>
	/// <param name="userId">The target user identifier.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The authenticator secret.</returns>
	Task<string> GetAsync(Guid userId, CancellationToken cancellationToken);
}

/// <summary>Authenticates current credentials and changes a user's password.</summary>
public interface IChangePassword
{
	/// <summary>Changes the password described by the request.</summary>
	/// <param name="request">The target identity, current password, and replacement password.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the password change.</returns>
	Task ChangeAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
}

/// <summary>Checks whether two-factor authentication is enabled for a user.</summary>
public interface IIsTwoFactorAuthenticationEnabled
{
	/// <summary>Returns whether two-factor authentication is enabled.</summary>
	/// <param name="userId">The target user identifier.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns><see langword="true"/> when enabled; otherwise <see langword="false"/>.</returns>
	Task<bool> IsEnabledAsync(Guid userId, CancellationToken cancellationToken);
}

/// <summary>Enables or disables two-factor authentication for a user.</summary>
public interface ISetTwoFactorAuthenticationEnabled
{
	/// <summary>Sets the user's two-factor enabled flag.</summary>
	/// <param name="userId">The target user identifier.</param>
	/// <param name="isEnabled">The requested enabled state.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the update.</returns>
	Task SetAsync(Guid userId, bool isEnabled, CancellationToken cancellationToken);
}

/// <summary>Validates a time-based authenticator code for a user.</summary>
public interface IValidateAuthenticatorCode
{
	/// <summary>Validates the code in the request and fails when it is invalid.</summary>
	/// <param name="request">The user identifier and authenticator code.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents validation.</returns>
	Task ValidateAsync(ValidateAuthenticatorCodeRequest request, CancellationToken cancellationToken);
}
