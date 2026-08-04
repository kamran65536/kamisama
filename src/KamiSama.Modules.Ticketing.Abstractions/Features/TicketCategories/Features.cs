using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Ticketing.Features.TicketCategories;

public interface IListTicketCategories : IListFeature<TicketCategoryListItemDto, TicketCategorySearchModel>;
public interface IAddTicketCategory : IAddFeature<AddTicketCategoryRequest, TicketCategoryDto>;
public interface IUpdateTicketCategory : IUpdateFeature<UpdateTicketCategoryRequest, Guid>;
public interface IDeleteTicketCategory : IDeleteFeature<Guid>;
public interface IFindTicketCategoryById : IFindByIdFeature<TicketCategoryDto, Guid>;
public interface IFindTicketCategoryByName : IFindByNameFeature<TicketCategoryDto>;
public interface IExistsTicketCategoryById : IExistsByIdFeature<Guid>;
public interface IExistsTicketCategoryByName : IExistsByNameFeature;