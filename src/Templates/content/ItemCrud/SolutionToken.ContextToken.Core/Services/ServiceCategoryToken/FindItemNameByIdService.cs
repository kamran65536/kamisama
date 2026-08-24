using KamiSama.Extensions.DependencyInjection;
using SolutionToken.ContextToken.Repositories.Abstractions;

namespace SolutionToken.ContextToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IFindItemNameById>]
internal sealed class FindItemNameByIdService(IItemNameRepository repository)
    : ItemNameFeatureDefinition.FindByIdBase(repository), IFindItemNameById;
