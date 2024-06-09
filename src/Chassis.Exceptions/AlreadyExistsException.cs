using KamiSama.Chassis.HttpExceptions.Properties;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The entity already exists exception
/// </summary>
/// <inheritdoc />
public class AlreadyExistsException(string entityName, string? entityKey) : ConflictException(nameof(Resources.AlreadyExistsException), entityName, entityKey)
{
}
