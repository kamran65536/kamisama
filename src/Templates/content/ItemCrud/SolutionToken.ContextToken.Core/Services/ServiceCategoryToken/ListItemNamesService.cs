using KamiSama.Extensions.DependencyInjection;
using SolutionToken.ContextToken.Repositories.Abstractions;

namespace SolutionToken.ContextToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IListItemNames>]
internal sealed class ListItemNamesService(IItemNameRepository repository)
    : ItemNameFeatureDefinition.ListBase(repository), IListItemNames;
