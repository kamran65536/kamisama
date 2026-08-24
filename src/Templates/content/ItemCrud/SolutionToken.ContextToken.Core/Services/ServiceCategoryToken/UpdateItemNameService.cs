using KamiSama.Extensions.DependencyInjection;
using SolutionToken.ContextToken.Repositories.Abstractions;

namespace SolutionToken.ContextToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IUpdateItemName>]
internal sealed class UpdateItemNameService(IItemNameRepository repository)
    : ItemNameFeatureDefinition.UpdateBase(repository), IUpdateItemName;
