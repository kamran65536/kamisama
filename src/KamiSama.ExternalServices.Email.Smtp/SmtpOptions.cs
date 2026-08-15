using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Email.Smtp;

/// <summary>
/// Contains the SMTP connection, credentials, TLS choice, and sender identity bound by the SMTP module.
/// </summary>
/// <remarks>
/// The current SMTP sender has a known inverted validation check: settings for which <see cref="IsValid"/> returns <see langword="true"/> are rejected before sending. This type documents the existing behavior; it does not correct that runtime defect.
/// </remarks>
public class SmtpOptions
{
	/// <summary>Gets or sets the SMTP server host name.</summary>
	[ConfigurationKeyName("host")]
	public required string? Host { get; set; }
	/// <summary>Gets or sets the SMTP server port. A value of zero is considered invalid by <see cref="IsValid"/>.</summary>
	[ConfigurationKeyName("port")]
	public required int Port { get; set; }
	/// <summary>Gets or sets the user name used to authenticate with the SMTP server.</summary>
	[ConfigurationKeyName("username")]
	public required string? Username { get; set; }
	/// <summary>Gets or sets the password used to authenticate with the SMTP server.</summary>
	[ConfigurationKeyName("password")]
	public required string? Password { get; set; }
	/// <summary>Gets or sets whether the SMTP client enables SSL.</summary>
	[ConfigurationKeyName("use-ssl")]
	public required bool UseSsl { get; set; }
	/// <summary>Gets or sets the email address placed in the message's From header.</summary>
	[ConfigurationKeyName("sender-address")]
	public required string? SenderAddress { get; set; }
	/// <summary>Gets or sets the display name placed in the message's From header.</summary>
	[ConfigurationKeyName("sender-name")]
	public required string? SenderAddressName { get; set; } = "noreply";

	/// <summary>
	/// Returns <see langword="true"/> when all required string settings are non-null and <see cref="Port"/> is nonzero.
	/// </summary>
	/// <returns><see langword="true"/> when the configured values pass these presence checks; otherwise, <see langword="false"/>.</returns>
	/// <remarks>The current internal SMTP sender incorrectly throws when this method returns <see langword="true"/>.</remarks>
	public bool IsValid() =>
		Host != null &&
		Port != 0 &&
		Username != null &&
		Password != null &&
		SenderAddress != null &&
		SenderAddressName != null;
}
