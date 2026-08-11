using Suma.AdminPanel.Services.Operators;
using KamiSama.Extensions.Paging;
using KamiSama.Extensions.DependencyInjection;
using Polareum.Commons.RestSharp;

namespace Suma.AdminPanel.Client.Services.Operators;

[AutoInjectScoped<IListOperators>]
public class ListOperatorsClientService(IRestBuilder restBuilder) : IListOperators
{
	public Task<PagedResult<OperatorListItemDto>> ListAsync(OperatorSearchModel searchModel, CancellationToken cancellationToken)
		=> restBuilder
			.ForServiceUrl("api/operators", "")
			.AddQueryParameter(searchModel)
			.GetAsync<PagedResult<OperatorListItemDto>>(cancellationToken);
}
