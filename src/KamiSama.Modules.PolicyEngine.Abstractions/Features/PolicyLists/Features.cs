using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyLists;

/// <summary>
/// Lists persisted policy-list definitions using paging and optional list filters.
/// </summary>
public interface IListPolicyLists : IListFeature<PolicyListListItemDto, PolicyListSearchModel>;

/// <summary>
/// Creates a named typed policy-list definition without adding list items.
/// </summary>
public interface IAddPolicyList : IAddFeature<AddPolicyListRequest, PolicyListDto>;

/// <summary>
/// Updates the named typed policy-list definition identified by a <see cref="Guid"/>.
/// </summary>
public interface IUpdatePolicyList : IUpdateFeature<UpdatePolicyListRequest, Guid>;

/// <summary>
/// Deletes the policy-list definition identified by a <see cref="Guid"/>.
/// </summary>
public interface IDeletePolicyList : IDeleteFeature<Guid>;

/// <summary>
/// Finds one persisted policy-list definition by its <see cref="Guid"/> identifier.
/// </summary>
public interface IFindPolicyListById : IFindByIdFeature<PolicyListDto, Guid>;
