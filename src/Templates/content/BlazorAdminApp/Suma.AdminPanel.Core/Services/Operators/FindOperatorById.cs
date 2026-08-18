using KamiSama.Chassis.HttpExceptions;
using KamiSama.Modules.Identity.DataTypes;
using KamiSama.Modules.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Operators;

[AutoInjectScoped<IFindOperatorById>]
internal class FindOperatorById(
	ILogger<FindOperatorById> logger,
	IFindUserById findUserById,
	IFindCurrentUser findCurrentUser) : IFindOperatorById
{
	public async Task<OperatorDto> FindByIdAsync(Guid operatorId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
			var identityUser = await findUserById.FindByIdAsync(operatorId, cancellationToken);
			if (!identityUser.Roles.Contains(KnownRoles.Operator))
				throw new NotFoundException("operator.not.found", operatorId, nameof(operatorId));

			return identityUser.ToOperatorDto(currentUser.Id);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to find operator {OperatorId}.", operatorId);
			throw;
		}
	}
}
