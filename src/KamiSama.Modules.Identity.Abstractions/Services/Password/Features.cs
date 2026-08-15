namespace KamiSama.Modules.Identity.Services.Password;

/// <summary>Validates a candidate password against an implementation's configured password policy.</summary>
public interface IValidatePassword
{
	/// <summary>Returns all password-policy errors detected for the supplied identity context and candidate password.</summary>
	/// <param name="request">The optional identity context and candidate password.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>The validation errors; an empty array indicates that the password passed validation.</returns>
	Task<PasswordValidationError[]> ValidateAsync(ValidatePasswordRequest request, CancellationToken cancellationToken);
}
/// <summary>Resets a user's password according to implementation-defined identity lookup and token validation rules.</summary>
public interface IResetPassword
{
	/// <summary>Resets the password for the identity in the request.</summary>
	/// <param name="request">The identity lookup value and replacement password.</param>
	/// <param name="cancellationToken">A token that requests cancellation.</param>
	/// <returns>A task that represents the reset operation.</returns>
	Task ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken);
}
