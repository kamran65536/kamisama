using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Sms.NeoZarin;
public class NeoZarinSmsOptions
{
	[ConfigurationKeyName("base-url")]
	public string? BaseUrl { get; set; } = "http://dashboard.neozarin.com";
	[ConfigurationKeyName("username")]
	public string? Username { get; set; }
	[ConfigurationKeyName("password")]
	public string? Password { get; set; }

	[ConfigurationKeyName("sms-api-path")]
	public string? SmsApiPath { get; set; } = "/api/json/sendgroupget";
	[ConfigurationKeyName("sms-sender-number")]
	public string? SmsSenderPhoneNumber { get; set; }
	[ConfigurationKeyName("sms-api-key")]
	public string? SmsApi { get; set; }

	public bool IsValidForSms() =>
        BaseUrl != null &&
        Username != null &&
        Password != null &&
		SmsSenderPhoneNumber != null &&
		SmsApiPath != null &&
		SmsApi != null;
}
