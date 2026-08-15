using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyRules;

/// <summary>
/// Lists persisted policy-rule definitions using paging and optional rule filters.
/// </summary>
public interface IListPolicyRules : IListFeature<PolicyRuleListItemDto, PolicyRuleSearchModel>;

/// <summary>
/// Creates an ordered policy-rule definition without evaluating its condition source.
/// </summary>
public interface IAddPolicyRule : IAddFeature<AddPolicyRuleRequest, PolicyRuleDto>;

/// <summary>
/// Updates the policy-rule definition identified by a <see cref="Guid"/>.
/// </summary>
public interface IUpdatePolicyRule : IUpdateFeature<UpdatePolicyRuleRequest, Guid>;

/// <summary>
/// Deletes the policy-rule definition identified by a <see cref="Guid"/>.
/// </summary>
public interface IDeletePolicyRule : IDeleteFeature<Guid>;

/// <summary>
/// Finds one persisted policy-rule definition by its <see cref="Guid"/> identifier.
/// </summary>
public interface IFindPolicyRuleById : IFindByIdFeature<PolicyRuleDto, Guid>;
