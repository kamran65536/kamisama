namespace KamiSama.Modules.Otp.DataTypes;

/// <summary>
/// Describes the lifecycle state of a persisted one-time-password record.
/// </summary>
public enum OtpRecordStatus : int
{
	/// <summary>The code has been generated and can still be verified before it expires.</summary>
	Available = 0,
	/// <summary>The code's lifetime elapsed before it was successfully verified.</summary>
	Expired = 1,
	/// <summary>The code was successfully verified and consumed.</summary>
	Used = 2,
}
