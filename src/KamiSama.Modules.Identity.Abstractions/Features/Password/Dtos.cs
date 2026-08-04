namespace KamiSama.Modules.Identity.Features.Password;

public record ValidatePasswordRequest(string? Username, string? Email, string? PhoneNumber, string Password);
public record PasswordValidationError(string Code, string Description);
public record ResetPasswordRequest(string Identity, string Password);
