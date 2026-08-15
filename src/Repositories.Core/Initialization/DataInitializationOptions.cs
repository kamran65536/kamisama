using Microsoft.Extensions.Configuration;

namespace KamiSama.Repositories.Initialization;

/// <summary>
/// Selects which migration and seed-data stages a database initializer should run.
/// </summary>
public class DataInitializationOptions
{
    /// <summary>
    /// Gets or sets whether the initializer should migrate the database.
    /// </summary>
    [ConfigurationKeyName("migrate")]
    public bool Migrate { get; set; }
    /// <summary>
    /// Gets or sets whether the initializer should create required application data.
    /// </summary>
    [ConfigurationKeyName("initialize")]
    public bool InitializeData { get; set; }
    /// <summary>
    /// Gets or sets whether the initializer should create test data.
    /// </summary>
    [ConfigurationKeyName("test-data")]
    public bool InitializeTestData { get; set; }
}
