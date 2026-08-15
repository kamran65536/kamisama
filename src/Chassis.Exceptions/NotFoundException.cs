namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Represents a request for an entity that could not be found.
/// </summary>
/// <param name="entityName">The entity type or display name included in localization arguments.</param>
/// <param name="entityKey">The key value that was not found.</param>
/// <param name="keyType">The name of the key, such as <c>id</c> or <c>name</c>.</param>
public class NotFoundException(string entityName, object? entityKey, string keyType = "key") : 
	HttpExceptionBase(nameof(NotFoundException), entityName, keyType, entityKey)
{
	/// <summary>Gets HTTP status code 404.</summary>
	public override int StatusCode => 404;
}
/// <summary>
/// Represents a request for an entity of type <typeparamref name="TEntity"/> that could not be found.
/// </summary>
/// <typeparam name="TEntity">The entity type whose name is included in localization arguments.</typeparam>
/// <param name="entityKey">The key value that was not found.</param>
/// <param name="keyType">The name of the key, such as <c>id</c> or <c>name</c>.</param>
public class NotFoundException<TEntity>(object? entityKey, string keyType = "key")
	: NotFoundException(typeof(TEntity).Name, entityKey, keyType)
{
}
