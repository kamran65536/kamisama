using Microsoft.Extensions.Configuration;

namespace KamiSama.Repositories;

/// <summary>
/// ConnectionString configuration
/// </summary>
public class ConnectionStringOption
{
	/// <summary>
	/// the Connection String
	/// </summary>
	[ConfigurationKeyName("connection-string")]
	public string? ConnectionString { get; set; }
	/// <summary>
	/// the database provider used for this configuration
	/// </summary>
	[ConfigurationKeyName("provider")]
	public string? Provider { get; set; }
}
