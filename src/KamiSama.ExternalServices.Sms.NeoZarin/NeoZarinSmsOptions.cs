using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Sms.NeoZarin;

/// <summary>
/// Contains the NeoZarin endpoint, credentials, sender number, and API identifier bound by the NeoZarin SMS module.
/// </summary>
/// <remarks>
/// The current NeoZarin sender has a known inverted validation check: settings for which <see cref="IsValidForSms"/> returns <see langword="true"/> are rejected before sending. This type documents the existing behavior; it does not correct that runtime defect.
/// </remarks>
public class NeoZarinSmsOptions
{
	/// <summary>Gets or sets the NeoZarin service base URL. The built-in default uses plain HTTP; configure the provider's HTTPS URL when available.</summary>
	[ConfigurationKeyName("base-url")]
	public string? BaseUrl { get; set; } = "http://dashboard.neozarin.com";
	/// <summary>Gets or sets the NeoZarin user name. Load credentials from protected configuration rather than source control.</summary>
	[ConfigurationKeyName("username")]
	public string? Username { get; set; }
	/// <summary>Gets or sets the NeoZarin password. Load this secret from protected configuration rather than source control.</summary>
	[ConfigurationKeyName("password")]
	public string? Password { get; set; }

	/// <summary>Gets or sets the relative NeoZarin group-send endpoint path.</summary>
	[ConfigurationKeyName("sms-api-path")]
	public string? SmsApiPath { get; set; } = "/api/json/sendgroupget";
	/// <summary>Gets or sets the sender number passed as the NeoZarin <c>from</c> parameter.</summary>
	[ConfigurationKeyName("sms-sender-number")]
	public string? SmsSenderPhoneNumber { get; set; }
	/// <summary>Gets or sets the NeoZarin SMS API identifier passed as the <c>api</c> parameter. Treat it as a secret and keep it out of source control.</summary>
	[ConfigurationKeyName("sms-api-key")]
	public string? SmsApi { get; set; }

	/// <summary>
	/// Returns <see langword="true"/> when every endpoint, credential, sender, and API value required by the sender is non-null.
	/// </summary>
	/// <returns><see langword="true"/> when all required SMS settings are present; otherwise, <see langword="false"/>.</returns>
	/// <remarks>The current internal NeoZarin sender incorrectly throws when this method returns <see langword="true"/>.</remarks>
	public bool IsValidForSms() =>
        BaseUrl != null &&
        Username != null &&
        Password != null &&
		SmsSenderPhoneNumber != null &&
		SmsApiPath != null &&
		SmsApi != null;
}
