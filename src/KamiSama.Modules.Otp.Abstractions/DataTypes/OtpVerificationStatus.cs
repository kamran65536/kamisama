namespace KamiSama.Modules.Otp.DataTypes;

/// <summary>
/// Describes the outcome of an OTP verification attempt.
/// </summary>
public enum OtpVerificationStatus : int
{
	/// <summary>The supplied code or token matched an available record and verification succeeded.</summary>
	Success = 0,
	/// <summary>The matching record's lifetime had already elapsed.</summary>
	Expired = 1,
	/// <summary>No matching available record was found for the supplied code or token.</summary>
	InvalidCode = 2,
}
