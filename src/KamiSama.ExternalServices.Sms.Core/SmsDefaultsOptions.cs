using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Sms;

/// <summary>
/// Selects the keyed SMS provider used by the core <c>ISendSms</c> dispatcher.
/// Bind it from the configuration section passed to <c>AddSmsCoreServicesModule</c>.
/// </summary>
public class SmsDefaultsOptions
{
	/// <summary>
	/// Gets or sets the provider key. Supported keys supplied by these packages are <c>mock</c>, <c>kavenegar</c>, and <c>neo-zarin</c>; the default is <c>mock</c>.
	/// </summary>
    [ConfigurationKeyName("sms")]
    public string Sms { get; set; } = "mock";
}
