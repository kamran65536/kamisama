using Suma.AdminPanel.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Suma.AdminPanel.Server.Controllers;

/// <summary>
/// Provides user management endpoints for AdminPanel.
/// </summary>
[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
	/// <summary>
	/// Lists users using the given search model.
	/// </summary>
	[HttpGet]
	public Task<PagedResult<UserListItemDto>> ListAsync(
		[FromServices] IListUsers service,
		[FromQuery] UserSearchModel? searchModel,
		CancellationToken cancellationToken)
		=> service.ListAsync(searchModel ?? UserSearchModel.All, cancellationToken);

	/// <summary>
	/// Finds an user by identifier.
	/// </summary>
	[HttpGet("{userId:guid}")]
	public Task<UserDto> FindByIdAsync(
		[FromServices] IFindUserById service,
		[FromRoute] Guid userId,
		CancellationToken cancellationToken)
		=> service.FindByIdAsync(userId, cancellationToken);

	/// <summary>
	/// Adds a new user.
	/// </summary>
	[HttpPost]
	public Task AddAsync(
		[FromServices] IAddUser service,
		[FromBody] AddUserRequest request,
		CancellationToken cancellationToken)
		=> service.AddAsync(request, cancellationToken);

	/// <summary>
	/// Updates user information.
	/// </summary>
	[HttpPut("{userId:guid}")]
	public Task UpdateAsync(
		[FromServices] IUpdateUser service,
		[FromRoute] Guid userId,
		[FromBody] UpdateUserRequest request,
		CancellationToken cancellationToken)
		=> service.UpdateAsync(userId, request, cancellationToken);

	/// <summary>
	/// Enables an user.
	/// </summary>
	[HttpPost("{userId:guid}/enable")]
	public Task EnableAsync(
		[FromServices] IEnableUser service,
		[FromRoute] Guid userId,
		CancellationToken cancellationToken)
		=> service.EnableAsync(userId, cancellationToken);

	/// <summary>
	/// Disables an user.
	/// </summary>
	[HttpPost("{userId:guid}/disable")]
	public Task DisableAsync(
		[FromServices] IDisableUser service,
		[FromRoute] Guid userId,
		CancellationToken cancellationToken)
		=> service.DisableAsync(userId, cancellationToken);

	/// <summary>
	/// Resets an user password.
	/// </summary>
	[HttpPost("reset-password")]
	public Task ResetPasswordAsync(
		[FromServices] IResetUserPassword service,
		[FromBody] ResetUserPasswordRequest request,
		CancellationToken cancellationToken)
		=> service.ResetPasswordAsync(request, cancellationToken);
}

