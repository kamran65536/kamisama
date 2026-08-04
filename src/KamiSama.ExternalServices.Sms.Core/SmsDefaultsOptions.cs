using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Sms;

public class SmsDefaultsOptions
{
    [ConfigurationKeyName("sms")]
    public string Sms { get; set; } = "mock";
}
