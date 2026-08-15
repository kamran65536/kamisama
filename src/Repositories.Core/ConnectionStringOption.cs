using Microsoft.Extensions.Configuration;

namespace KamiSama.Repositories;

/// <summary>
/// Holds the provider name and connection string bound from a configuration section.
/// </summary>
public class ConnectionStringOption
{
	/// <summary>
	/// Gets or sets the database connection string bound from the <c>connection-string</c> key.
	/// </summary>
	[ConfigurationKeyName("connection-string")]
	public string? ConnectionString { get; set; }
	/// <summary>
	/// Gets or sets the provider identifier bound from the <c>provider</c> key.
	/// </summary>
	[ConfigurationKeyName("provider")]
	public string? Provider { get; set; }
}
