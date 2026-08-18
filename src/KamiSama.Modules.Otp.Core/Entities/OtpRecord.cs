using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Otp.Entities;

/// <summary>
/// Represents a persisted one-time-password record for an identity.
/// </summary>
public class OtpRecord
{
	/// <summary>Gets or sets the record identifier.</summary>
	/// <value>The EF Core primary key.</value>
	public Guid Id { get; set; }

	/// <summary>Gets or sets the identity (such as a phone number or email address) this code was generated for.</summary>
	/// <value>A value with a maximum persisted length of 100 characters.</value>
	[MaxLength(100)]
	public required string Identity { get; set; }

	/// <summary>Gets or sets the generated numeric OTP code.</summary>
	/// <value>A value with a maximum persisted length of 10 characters.</value>
	[MaxLength(10)]
	public required string Code { get; set; }

	/// <summary>Gets or sets the reusable token issued after successful verification.</summary>
	/// <value><see langword="null"/> until the record is successfully verified by <c>VerifyOtp</c>.</value>
	public string? VerificationToken { get; set; }

	/// <summary>Gets or sets the current lifecycle status of the record.</summary>
	/// <value>Starts as <see cref="OtpRecordStatus.Available"/> and transitions to <see cref="OtpRecordStatus.Used"/> or <see cref="OtpRecordStatus.Expired"/>.</value>
	public required OtpRecordStatus Status { get; set; }

	/// <summary>Gets or sets the UTC timestamp the record was generated at.</summary>
	/// <value>Set once at creation and used to enforce the resend interval.</value>
	public DateTime CreatedAt { get; set; }

	/// <summary>Gets or sets the UTC timestamp after which the code can no longer be verified.</summary>
	/// <value>Computed at creation from the configured OTP lifetime.</value>
	public DateTime ExpirationDate { get; set; }
}
