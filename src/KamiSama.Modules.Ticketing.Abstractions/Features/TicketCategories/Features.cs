using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Ticketing.Features.TicketCategories;

/// <summary>
/// Lists a page of ticket categories matching name and ordering criteria.
/// Implementations define persistence and exact filtering semantics.
/// </summary>
public interface IListTicketCategories : IListFeature<TicketCategoryListItemDto, TicketCategorySearchModel>;
/// <summary>
/// Creates a ticket category and returns its persisted representation.
/// Core rejects an existing case-insensitive name before insertion.
/// </summary>
public interface IAddTicketCategory : IAddFeature<AddTicketCategoryRequest, TicketCategoryDto>;
/// <summary>
/// Updates a ticket category identified by a <see cref="Guid"/>.
/// Core replaces the name and rejects a case-insensitive name owned by another category.
/// </summary>
public interface IUpdateTicketCategory : IUpdateFeature<UpdateTicketCategoryRequest, Guid>;
/// <summary>
/// Deletes a ticket category identified by a <see cref="Guid"/>.
/// Implementations determine relationship and missing-category behavior.
/// </summary>
public interface IDeleteTicketCategory : IDeleteFeature<Guid>;
/// <summary>
/// Finds a ticket category by its <see cref="Guid"/> identifier.
/// Implementations determine missing-category behavior.
/// </summary>
public interface IFindTicketCategoryById : IFindByIdFeature<TicketCategoryDto, Guid>;
/// <summary>
/// Finds a ticket category by name.
/// Core performs a case-insensitive exact comparison.
/// </summary>
public interface IFindTicketCategoryByName : IFindByNameFeature<TicketCategoryDto>;
/// <summary>
/// Tests whether a ticket category exists for a <see cref="Guid"/> identifier.
/// Implementations define the underlying lookup behavior.
/// </summary>
public interface IExistsTicketCategoryById : IExistsByIdFeature<Guid>;
/// <summary>
/// Tests whether a ticket category exists for a name.
/// Core's repository performs a case-insensitive exact comparison.
/// </summary>
public interface IExistsTicketCategoryByName : IExistsByNameFeature;
