using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Email.Smtp;

public class SmtpOptions
{
	[ConfigurationKeyName("host")]
	public required string? Host { get; set; }
	[ConfigurationKeyName("port")]
	public required int Port { get; set; }
	[ConfigurationKeyName("username")]
	public required string? Username { get; set; }
	[ConfigurationKeyName("password")]
	public required string? Password { get; set; }
	[ConfigurationKeyName("use-ssl")]
	public required bool UseSsl { get; set; }
	[ConfigurationKeyName("sender-address")]
	public required string? SenderAddress { get; set; }
	[ConfigurationKeyName("sender-name")]
	public required string? SenderAddressName { get; set; } = "noreply";

	public bool IsValid() =>
		Host != null &&
		Port != 0 &&
		Username != null &&
		Password != null &&
		SenderAddress != null &&
		SenderAddressName != null;
}
