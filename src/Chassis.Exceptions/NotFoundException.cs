using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Entity not found
/// </summary>
/// <inheritdoc />
[ExcludeFromCodeCoverage]
public class NotFoundException(string entityName, object? entityKey) : HttpExceptionBase($"{entityName} with key {entityKey} does not exists")
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status404NotFound;
}
