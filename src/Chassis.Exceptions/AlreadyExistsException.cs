namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The entity already exists exception
/// </summary>
/// <inheritdoc />
public class AlreadyExistsException(string entityName, object entityKey, string keyType = "key") : 
	ConflictException(nameof(AlreadyExistsException), entityName, keyType, entityKey)
{
}
/// <summary>
/// The entity already exists exception
/// </summary>
/// <inheritdoc />
public class AlreadyExistsException<TEntity>(object entityKey, string keyType = "key")
	: AlreadyExistsException(typeof(TEntity).Name, entityKey, keyType)
{
}
