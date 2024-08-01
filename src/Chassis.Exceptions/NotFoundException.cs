using Microsoft.AspNetCore.Http;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Entity not found
/// </summary>
/// <inheritdoc />
public class NotFoundException(string entityName, object? entityKey) : HttpExceptionBase(nameof(NotFoundException), entityName, entityKey)
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status404NotFound;
}
/// <summary>
/// Entity not found
/// </summary>
/// <inheritdoc />
public class NotFoundException<TEntity>(object? entityKey)
	: NotFoundException(typeof(TEntity).Name, entityKey)
{
}