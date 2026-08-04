using Microsoft.Extensions.Configuration;

namespace KamiSama.ExternalServices.Email;

public class EmailDefaultsOptions
{
    [ConfigurationKeyName("email")]
    public string Email { get; set; } = "mock";
}
