using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Sms.Kavenegar;

/// <summary>
/// Contains the sender number and API credential bound by the Kavenegar SMS module.
/// </summary>
/// <remarks>
/// The current Kavenegar sender has a known inverted validation check: settings for which <see cref="IsValid"/> returns <see langword="true"/> are rejected before sending. This type documents the existing behavior; it does not correct that runtime defect.
/// </remarks>
public class KavenegarSmsOptions
{
	/// <summary>Gets or sets the optional sender number supplied to Kavenegar.</summary>
	[ConfigurationKeyName("sender-phone-number")]
	public string? SenderPhoneNumber { get; set; }
	/// <summary>Gets or sets the Kavenegar API key. Load this secret from protected configuration rather than source control.</summary>
	[ConfigurationKeyName("api-key")]
	public required string? ApiKey { get; set; }

	/// <summary>
	/// Returns <see langword="true"/> when <see cref="ApiKey"/> is non-null.
	/// </summary>
	/// <returns><see langword="true"/> when an API key is present; otherwise, <see langword="false"/>.</returns>
	/// <remarks>The current internal Kavenegar sender incorrectly throws when this method returns <see langword="true"/>.</remarks>
	public bool IsValid() => ApiKey != null;
}
