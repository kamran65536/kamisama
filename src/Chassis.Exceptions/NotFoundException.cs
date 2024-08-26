using Microsoft.AspNetCore.Http;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Entity not found
/// </summary>
/// <inheritdoc />
public class NotFoundException(string entityName, object? entityKey, string keyType = "key") : 
	HttpExceptionBase(nameof(NotFoundException), entityName, keyType, entityKey)
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status404NotFound;
}
/// <summary>
/// Entity not found
/// </summary>
/// <inheritdoc />
public class NotFoundException<TEntity>(object? entityKey, string keyType = "key")
	: NotFoundException(typeof(TEntity).Name, entityKey, keyType)
{
}