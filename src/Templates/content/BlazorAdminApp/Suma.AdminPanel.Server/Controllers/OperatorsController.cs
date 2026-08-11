using Suma.AdminPanel.Services.Operators;
using Microsoft.AspNetCore.Mvc;

namespace Suma.AdminPanel.Server.Controllers;

/// <summary>
/// Provides operator management endpoints for AdminPanel.
/// </summary>
[Route("api/operators")]
[ApiController]
public class OperatorsController : ControllerBase
{
	/// <summary>
	/// Lists operators using the given search model.
	/// </summary>
	[HttpGet]
	public Task<PagedResult<OperatorListItemDto>> ListAsync(
		[FromServices] IListOperators service,
		[FromQuery] OperatorSearchModel? searchModel,
		CancellationToken cancellationToken)
		=> service.ListAsync(searchModel ?? OperatorSearchModel.All, cancellationToken);

	/// <summary>
	/// Finds an operator by identifier.
	/// </summary>
	[HttpGet("{operatorId:guid}")]
	public Task<OperatorDto> FindByIdAsync(
		[FromServices] IFindOperatorById service,
		[FromRoute] Guid operatorId,
		CancellationToken cancellationToken)
		=> service.FindByIdAsync(operatorId, cancellationToken);

	/// <summary>
	/// Adds a new operator.
	/// </summary>
	[HttpPost]
	public Task AddAsync(
		[FromServices] IAddOperator service,
		[FromBody] AddOperatorRequest request,
		CancellationToken cancellationToken)
		=> service.AddAsync(request, cancellationToken);

	/// <summary>
	/// Updates operator information.
	/// </summary>
	[HttpPut("{operatorId:guid}")]
	public Task UpdateAsync(
		[FromServices] IUpdateOperator service,
		[FromRoute] Guid operatorId,
		[FromBody] UpdateOperatorRequest request,
		CancellationToken cancellationToken)
		=> service.UpdateAsync(operatorId, request, cancellationToken);

	/// <summary>
	/// Enables an operator.
	/// </summary>
	[HttpPost("{operatorId:guid}/enable")]
	public Task EnableAsync(
		[FromServices] IEnableOperator service,
		[FromRoute] Guid operatorId,
		CancellationToken cancellationToken)
		=> service.EnableAsync(operatorId, cancellationToken);

	/// <summary>
	/// Disables an operator.
	/// </summary>
	[HttpPost("{operatorId:guid}/disable")]
	public Task DisableAsync(
		[FromServices] IDisableOperator service,
		[FromRoute] Guid operatorId,
		CancellationToken cancellationToken)
		=> service.DisableAsync(operatorId, cancellationToken);

	/// <summary>
	/// Resets an operator password.
	/// </summary>
	[HttpPost("reset-password")]
	public Task ResetPasswordAsync(
		[FromServices] IResetOperatorPassword service,
		[FromBody] ResetOperatorPasswordRequest request,
		CancellationToken cancellationToken)
		=> service.ResetPasswordAsync(request, cancellationToken);
}
