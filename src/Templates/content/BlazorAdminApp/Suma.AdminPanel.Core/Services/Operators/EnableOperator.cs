using KamiSama.Chassis.HttpExceptions;
using Polareum.Identity.DataTypes;
using Polareum.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Operators;

[AutoInjectScoped<IEnableOperator>]
internal class EnableOperator(
	ILogger<EnableOperator> logger,
	IFindUserById findUserById,
	IFindCurrentUser findCurrentUser,
	IEnableUser enableUser) : IEnableOperator
{
	public async Task EnableAsync(Guid operatorId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await findUserById.FindByIdAsync(operatorId, cancellationToken);
			var isEditable = !identityUser.Roles.Contains(KnownRoles.SuperAdmin) && identityUser.Id != currentUser.Id;

			if (!isEditable)
				throw new NotFoundException("operator.not.found", operatorId, nameof(operatorId));

			await enableUser.EnableUserAsync(operatorId, cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to enable operator {OperatorId}.", operatorId);
			throw;
		}
	}
}
