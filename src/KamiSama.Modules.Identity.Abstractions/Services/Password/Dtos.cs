namespace KamiSama.Modules.Identity.Services.Password;

/// <summary>Supplies optional identity context and a candidate password for policy validation.</summary>
/// <param name="Username">An optional user name used to create validation context.</param>
/// <param name="Email">An optional email address used to create validation context.</param>
/// <param name="PhoneNumber">An optional phone number used to create validation context.</param>
/// <param name="Password">The candidate password.</param>
public record ValidatePasswordRequest(string? Username, string? Email, string? PhoneNumber, string Password);
/// <summary>Describes one password-policy validation failure.</summary>
/// <param name="Code">The stable provider error code.</param>
/// <param name="Description">The human-readable provider error description.</param>
public record PasswordValidationError(string Code, string Description);
/// <summary>Supplies an identity lookup value and replacement password to a reset implementation.</summary>
/// <param name="Identity">The user name or email address interpreted by the implementation.</param>
/// <param name="Password">The replacement password.</param>
public record ResetPasswordRequest(string Identity, string Password);
