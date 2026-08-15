using KamiSama.Modules.PolicyEngine.Features.PolicyActions;

namespace KamiSama.Modules.PolicyEngine.Repositories.Abstractions;

internal interface IPolicyActionRepository :
	IGenericRepository<PolicyAction, PolicyActionSearchModel>,
	ILookupByIdRepository<PolicyAction, Guid>,
	ILookupByNameRepository<PolicyAction>
{
}
