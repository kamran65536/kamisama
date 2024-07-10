namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The entity already exists exception
/// </summary>
/// <inheritdoc />
public class AlreadyExistsException(string entityName, object entityKey) : ConflictException(nameof(AlreadyExistsException), entityName, entityKey)
{
}
/// <summary>
/// The entity already exists exception
/// </summary>
/// <inheritdoc />
public class AlreadyExistsException<TEntity>(object entityKey)
	: AlreadyExistsException(nameof(TEntity), entityKey)
{
}
