namespace KamiSama.Repositories;

/// <summary>
/// Connection string options
/// </summary>
public class ConnectionStringInfo
{
	/// <summary>
	/// Connection string
	/// </summary>
	public required string ConnectionString { get; set; }
	/// <summary>
	/// Database provider
	/// </summary>
	public required string Provider { get; set; }
}
