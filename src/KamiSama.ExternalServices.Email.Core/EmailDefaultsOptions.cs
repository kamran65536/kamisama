using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Email;

/// <summary>
/// Selects the keyed email provider used by the core <c>ISendEmail</c> dispatcher.
/// Bind it from the configuration section passed to <c>AddCoreEmailServices</c>.
/// </summary>
public class EmailDefaultsOptions
{
    /// <summary>
    /// Gets or sets the keyed provider name. The built-in default is <c>mock</c>; SMTP is registered under <c>smtp</c> when its provider module is added.
    /// </summary>
    [ConfigurationKeyName("email")]
    public string Email { get; set; } = "mock";
}
