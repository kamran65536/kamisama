using KamiSama.Chassis.Commons.Features;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

public interface IAddItemName : IAddFeature<AddItemNameRequest, ItemNameDto>;
public interface IUpdateItemName : IUpdateFeature<UpdateItemNameRequest, KeyTypeToken>;
public interface IDeleteItemName : IDeleteFeature<KeyTypeToken>;
public interface IFindItemNameById : IFindByIdFeature<ItemNameDto, KeyTypeToken>;
public interface IListItemNames : IListFeature<ItemNameListItemDto, ItemNameSearchModel>;
