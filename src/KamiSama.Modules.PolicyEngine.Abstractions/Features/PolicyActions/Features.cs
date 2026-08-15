using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyActions;

/// <summary>
/// Lists persisted policy-action definitions using paging and optional action filters.
/// </summary>
public interface IListPolicyActions : IListFeature<PolicyActionListItemDto, PolicyActionSearchModel>;

/// <summary>
/// Creates a reusable policy-action definition and returns its persisted representation.
/// </summary>
public interface IAddPolicyAction : IAddFeature<AddPolicyActionRequest, PolicyActionDto>;

/// <summary>
/// Updates the definition identified by a <see cref="Guid"/> without executing its handler.
/// </summary>
public interface IUpdatePolicyAction : IUpdateFeature<UpdatePolicyActionRequest, Guid>;

/// <summary>
/// Deletes the policy-action definition identified by a <see cref="Guid"/>.
/// </summary>
public interface IDeletePolicyAction : IDeleteFeature<Guid>;

/// <summary>
/// Finds one persisted policy-action definition by its <see cref="Guid"/> identifier.
/// </summary>
public interface IFindPolicyActionById : IFindByIdFeature<PolicyActionDto, Guid>;
