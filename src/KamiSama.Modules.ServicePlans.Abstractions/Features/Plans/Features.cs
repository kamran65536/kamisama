using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

/// <summary>
/// Defines paged plan listing using plan-specific filters and ordering.
/// </summary>
public interface IListPlans : IListFeature<PlanListItemDto, PlanSearchModel>;
/// <summary>
/// Defines creation of a subscription plan and return of its persisted representation.
/// </summary>
public interface IAddPlan : IAddFeature<AddPlanRequest, PlanDto>;
/// <summary>
/// Defines replacement of plan values selected by a <see cref="Guid"/> identifier.
/// </summary>
public interface IUpdatePlan : IUpdateFeature<UpdatePlanRequest, Guid>;
/// <summary>
/// Defines deletion of a plan selected by a <see cref="Guid"/> identifier.
/// </summary>
public interface IDeletePlan : IDeleteFeature<Guid>;
/// <summary>
/// Defines lookup of one plan by its <see cref="Guid"/> identifier.
/// </summary>
public interface IFindPlanById : IFindByIdFeature<PlanDto, Guid>;
/// <summary>
/// Defines lookup of one plan by name.
/// </summary>
public interface IFindPlanByName : IFindByNameFeature<PlanDto>;
/// <summary>
/// Defines an existence check for a plan identifier.
/// </summary>
public interface IExistsPlanById : IExistsByIdFeature<Guid>;
/// <summary>
/// Defines an existence check for a plan name.
/// </summary>
public interface IExistsPlanByName : IExistsByNameFeature;
