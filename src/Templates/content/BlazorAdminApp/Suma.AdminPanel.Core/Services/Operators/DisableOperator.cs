using KamiSama.Chassis.HttpExceptions;
using Polareum.Identity.DataTypes;
using Polareum.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Operators;

[AutoInjectScoped<IDisableOperator>]
internal class DisableOperator(
	ILogger<DisableOperator> logger,
	IFindUserById findUserById,
	IFindCurrentUser findCurrentUser,
	IDisableUser disableUser) : IDisableOperator
{
	public async Task DisableAsync(Guid operatorId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await findUserById.FindByIdAsync(operatorId, cancellationToken);
			var isEditable = !identityUser.Roles.Contains(KnownRoles.SuperAdmin) && identityUser.Id != currentUser.Id;

			if (!isEditable)
				throw new NotFoundException("operator.not.found", operatorId, nameof(operatorId));

			await disableUser.DisableUserAsync(operatorId, cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to disable operator {OperatorId}.", operatorId);
			throw;
		}
	}
}
