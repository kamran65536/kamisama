using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// Entity not found
/// </summary>
[ExcludeFromCodeCoverage]
public class NotFoundException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status404NotFound;
	/// <inheritdoc />
	public NotFoundException(string entityName, object? entityKey)
		: base($"{entityName} with key {entityKey} does not exists")
	{
	}
}
