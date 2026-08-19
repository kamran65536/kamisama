namespace KamiSama.Modules.Otp.Services;

/// <summary>
/// Generates and persists a new one-time password for an identity.
/// </summary>
public interface IGenerateOtp
{
	/// <summary>
	/// Generates a new OTP code for the requested identity, subject to the configured resend interval.
	/// </summary>
	/// <param name="request">The identity to generate a code for.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The generated numeric code as a string.</returns>
	Task<string> GenerateAsync(GenerateOtpRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// Verifies a one-time password code against the most recent available record for an identity.
/// </summary>
public interface IVerifyOtp
{
	/// <summary>
	/// Verifies the supplied code against the most recent available OTP record for the identity.
	/// </summary>
	/// <param name="request">The identity and code to verify.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The verification result, including a reusable token when verification succeeds.</returns>
	Task<OtpVerificationResult> VerifyAsync(VerifyOtpRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// Verifies a previously issued OTP verification token for an identity.
/// </summary>
public interface IVerifyOtpWithToken
{
	/// <summary>
	/// Verifies the supplied token against the matching OTP record for the identity.
	/// </summary>
	/// <param name="request">The identity and token to verify.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The verification result for the supplied token.</returns>
	Task<OtpVerificationResult> VerifyWithTokenAsync(VerifyOtpWithTokenRequest request, CancellationToken cancellationToken);
}
