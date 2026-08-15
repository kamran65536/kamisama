namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Represents a conflict in which an entity with the supplied key already exists.
/// </summary>
/// <param name="entityName">The entity type or display name included in localization arguments.</param>
/// <param name="entityKey">The duplicate key value.</param>
/// <param name="keyType">The name of the key, such as <c>id</c> or <c>name</c>.</param>
public class AlreadyExistsException(string entityName, object entityKey, string keyType = "key") : 
	ConflictException(nameof(AlreadyExistsException), entityName, keyType, entityKey)
{
}
/// <summary>
/// Represents a conflict in which an entity of type <typeparamref name="TEntity"/> already exists.
/// </summary>
/// <typeparam name="TEntity">The entity type whose name is included in localization arguments.</typeparam>
/// <param name="entityKey">The duplicate key value.</param>
/// <param name="keyType">The name of the key, such as <c>id</c> or <c>name</c>.</param>
public class AlreadyExistsException<TEntity>(object entityKey, string keyType = "key")
	: AlreadyExistsException(typeof(TEntity).Name, entityKey, keyType)
{
}
