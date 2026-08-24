using KamiSama.Extensions.DependencyInjection;
using SolutionToken.ContextToken.Repositories.Abstractions;

namespace SolutionToken.ContextToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IAddItemName>]
internal sealed class AddItemNameService(IItemNameRepository repository)
    : ItemNameFeatureDefinition.AddBase(repository), IAddItemName;
