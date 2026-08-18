using KamiSama.Modules.Identity.DataTypes;
using KamiSama.Modules.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Operators;

[AutoInjectScoped<IListOperators>]
internal class ListOperators(
	ILogger<ListOperators> logger,
	IListUsers listUsers,
	IFindCurrentUser findCurrentUser) : IListOperators
{
	public async Task<PagedResult<OperatorListItemDto>> ListAsync(OperatorSearchModel searchModel, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);

			var usernameOrEmail = string.IsNullOrWhiteSpace(searchModel.Username)
				? searchModel.Email
				: searchModel.Username;
			var identitySearchModel = new UserSearchModel(
				searchModel.Page,
				searchModel.PageSize,
				KnownRoles.Operator,
				usernameOrEmail,
				searchModel.OrderBy);

			var result = await listUsers.ListAsync(identitySearchModel, cancellationToken);

			return new PagedResult<OperatorListItemDto>(
				result.TotalItemsCount,
				[.. result.Items.Select(x => x.ToOperatorListItemDto(currentUser.Id))]);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to list operators.");
			throw;
		}
	}
}
