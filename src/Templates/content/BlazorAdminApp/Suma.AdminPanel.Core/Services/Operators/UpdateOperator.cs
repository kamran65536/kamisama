using KamiSama.Chassis.HttpExceptions;
using Polareum.Identity.DataTypes;
using Polareum.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Operators;

[AutoInjectScoped<IUpdateOperator>]
internal class UpdateOperator(
	ILogger<UpdateOperator> logger,
	IFindUserById findUserById,
	IFindCurrentUser findCurrentUser,
	IUpdateUser updateUser,
	IEnableUser enableUser,
	IDisableUser disableUser) : IUpdateOperator
{
	public async Task UpdateAsync(Guid operatorId, UpdateOperatorRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await findUserById.FindByIdAsync(operatorId, cancellationToken);
			var isEditable = !identityUser.Roles.Contains(KnownRoles.SuperAdmin) && identityUser.Id != currentUser.Id;

			if (!isEditable)
				throw new NotFoundException("operator.not.found", operatorId, nameof(operatorId));

			await updateUser.UpdateAsync(
				operatorId,
				new Polareum.Identity.Features.Users.UpdateUserRequest(
					request.Username,
					request.Email,
					string.Empty,
					[KnownRoles.Operator]),
				cancellationToken);

			if (identityUser.IsEnabled == request.IsEnabled)
				return;

			if (request.IsEnabled)
				await enableUser.EnableUserAsync(operatorId, cancellationToken);
			else
				await disableUser.DisableUserAsync(operatorId, cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to update operator {OperatorId}.", operatorId);
			throw;
		}
	}
}
