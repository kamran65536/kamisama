using KamiSama.Chassis.Commons.Repositories;
using SolutionToken.ContextToken.Services.ServiceCategoryToken;

namespace SolutionToken.ContextToken.Repositories.Abstractions;

internal interface IItemNameRepository
    : IGenericRepository<ItemName, ItemNameSearchModel>,
      ILookupByIdRepository<ItemName, KeyTypeToken>;
