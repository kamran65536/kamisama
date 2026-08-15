namespace KamiSama.Modules.Identity.Services.AccountSecurity;

/// <summary>Describes one active application session for account-security displays and revocation controls.</summary>
/// <param name="Id">The public session identifier.</param>
/// <param name="DeviceModel">The device description captured when the session was created.</param>
/// <param name="LastConnection">The last recorded connection time.</param>
/// <param name="IpAddress">The IP address captured for the session.</param>
/// <param name="IsCurrent">Whether this session is the caller's current session.</param>
public record ActiveSessionDto(
	string Id,
	string DeviceModel,
	DateTime LastConnection,
	string IpAddress,
	bool IsCurrent);

/// <summary>Supplies current credentials and a replacement password for a password-change workflow.</summary>
/// <param name="UserId">The target user's identifier.</param>
/// <param name="Username">The target user's name.</param>
/// <param name="Email">The target user's email address.</param>
/// <param name="CurrentPassword">The current password used to authenticate the request.</param>
/// <param name="NewPassword">The replacement password.</param>
public record ChangePasswordRequest(
	Guid UserId,
	string Username,
	string Email,
	string CurrentPassword,
	string NewPassword);

/// <summary>Supplies a user identifier and time-based authenticator code for validation.</summary>
/// <param name="UserId">The target user's identifier.</param>
/// <param name="AuthenticatorCode">The authenticator code to validate.</param>
public record ValidateAuthenticatorCodeRequest(
	Guid UserId,
	string AuthenticatorCode);
