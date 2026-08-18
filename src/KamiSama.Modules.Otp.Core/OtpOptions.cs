using Microsoft.Extensions.Configuration;

namespace KamiSama.Modules.Otp;

/// <summary>
/// Binds the configurable behavior of OTP code generation from the Otp module's configuration section.
/// </summary>
internal class OtpOptions
{
	/// <summary>Gets or sets the number of digits generated for each OTP code.</summary>
	/// <value>Bound from the <c>digits</c> configuration key; defaults to <c>6</c>.</value>
	[ConfigurationKeyName("digits")]
	public byte NumberOfDigits { get; internal set; } = 6;

	/// <summary>Gets or sets the minimum interval that must elapse before a new code can be generated for the same identity.</summary>
	/// <value>Bound from the <c>send-interval</c> configuration key; defaults to one minute.</value>
	[ConfigurationKeyName("send-interval")]
	public TimeSpan SendOtpInterval { get; set; } = TimeSpan.FromMinutes(1);

	/// <summary>Gets or sets how long a generated code remains available for verification.</summary>
	/// <value>Bound from the <c>lifetime</c> configuration key; defaults to five minutes.</value>
	[ConfigurationKeyName("lifetime")]
	public TimeSpan OtpLifetime { get; set; } = TimeSpan.FromMinutes(5);
}
