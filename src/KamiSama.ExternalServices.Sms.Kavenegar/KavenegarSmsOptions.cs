using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Sms.Kavenegar;

public class KavenegarSmsOptions
{
	[ConfigurationKeyName("sender-phone-number")]
	public string? SenderPhoneNumber { get; set; }
	[ConfigurationKeyName("api-key")]
	public required string? ApiKey { get; set; }

	public bool IsValid() => ApiKey != null;
}
