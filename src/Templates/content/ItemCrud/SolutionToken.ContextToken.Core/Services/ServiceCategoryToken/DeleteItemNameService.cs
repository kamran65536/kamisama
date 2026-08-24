using KamiSama.Extensions.DependencyInjection;
using SolutionToken.ContextToken.Repositories.Abstractions;

namespace SolutionToken.ContextToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IDeleteItemName>]
internal sealed class DeleteItemNameService(IItemNameRepository repository)
    : ItemNameFeatureDefinition.DeleteBase(repository), IDeleteItemName;
