namespace KamiSama.Modules.Identity.Services.AccountSecurity;

public record ActiveSessionDto(
	string Id,
	string DeviceModel,
	DateTime LastConnection,
	string IpAddress,
	bool IsCurrent);

public record ChangePasswordRequest(
	Guid UserId,
	string Username,
	string Email,
	string CurrentPassword,
	string NewPassword);

public record ValidateAuthenticatorCodeRequest(
	Guid UserId,
	string AuthenticatorCode);
