using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The entity already exists exception
/// </summary>
[ExcludeFromCodeCoverage]
public class AlreadyExistsException : ConflictException
{

	/// <inheritdoc />
	public AlreadyExistsException(string entityName, string? entityKey)
		: base($"{entityName} with key {entityKey} already exists.")
	{
	}
}
