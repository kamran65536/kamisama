using Microsoft.Extensions.Configuration;

namespace KamiSama.Repositories.Initialization;

/// <summary>
/// Data Initialization Options
/// </summary>
public class DataInitializationOptions
{
    /// <summary>
    /// Migrate database to the latest version
    /// </summary>
    [ConfigurationKeyName("migrate")]
    public bool Migrate { get; set; }
    /// <summary>
    /// Initialize necessary data to the database
    /// </summary>
    [ConfigurationKeyName("initialize")]
    public bool InitializeData { get; set; }
    /// <summary>
    /// Adds test data (for test purposes)
    /// </summary>
    [ConfigurationKeyName("test-data")]
    public bool InitializeTestData { get; set; }
}
