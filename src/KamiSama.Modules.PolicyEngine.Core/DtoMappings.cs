using KamiSama.Modules.PolicyEngine.Features.PolicyActions;
using KamiSama.Modules.PolicyEngine.Features.PolicyLists;
using KamiSama.Modules.PolicyEngine.Features.PolicyRules;
using Riok.Mapperly.Abstractions;

namespace KamiSama.Modules.PolicyEngine;

[Mapper]
internal static partial class DtoMappings
{
	[MapperIgnoreSource(nameof(PolicyAction.PolicyRuleActions))]
	[MapperIgnoreSource(nameof(PolicyAction.ConfigurationSource))]
	public static partial PolicyActionListItemDto ToListItemDto(this PolicyAction entity);

	[MapperIgnoreSource(nameof(PolicyAction.PolicyRuleActions))]
	public static partial PolicyActionDto ToDto(this PolicyAction entity);

	[MapperIgnoreSource(nameof(PolicyRule.PolicyRuleActions))]
	[MapperIgnoreSource(nameof(PolicyRule.ConditionSource))]
	public static partial PolicyRuleListItemDto ToListItemDto(this PolicyRule entity);

	[MapperIgnoreSource(nameof(PolicyRule.PolicyRuleActions))]
	public static partial PolicyRuleDto ToDto(this PolicyRule entity);

	[MapperIgnoreSource(nameof(PolicyList.Items))]
	public static partial PolicyListListItemDto ToListItemDto(this PolicyList entity);

	[MapperIgnoreSource(nameof(PolicyList.Items))]
	public static partial PolicyListDto ToDto(this PolicyList entity);
}
