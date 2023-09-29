using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The entity already exists exception
/// </summary>
/// <inheritdoc />
[ExcludeFromCodeCoverage]
public class AlreadyExistsException(string entityName, string? entityKey) : ConflictException($"{entityName} with key {entityKey} already exists.")
{
}
