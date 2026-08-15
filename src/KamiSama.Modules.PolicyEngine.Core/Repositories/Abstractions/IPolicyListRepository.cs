using KamiSama.Modules.PolicyEngine.Features.PolicyLists;

namespace KamiSama.Modules.PolicyEngine.Repositories.Abstractions;

internal interface IPolicyListRepository :
	IGenericRepository<PolicyList, PolicyListSearchModel>,
	ILookupByIdRepository<PolicyList, Guid>,
	ILookupByNameRepository<PolicyList>
{
}
