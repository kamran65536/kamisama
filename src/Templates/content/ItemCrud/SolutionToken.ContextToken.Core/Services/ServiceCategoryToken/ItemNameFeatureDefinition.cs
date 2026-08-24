using KamiSama.Chassis.Commons.Features;
using SolutionToken.ContextToken.Repositories.Abstractions;
using SolutionToken.ContextToken.Services.ServiceCategoryToken;

namespace SolutionToken.ContextToken;

internal abstract class ItemNameFeatureDefinition
    : FeatureDefinitionBase<ItemName, ItemNameDto, AddItemNameRequest, UpdateItemNameRequest,
        IItemNameRepository, ItemNameSearchModel, KeyTypeToken>
{
    internal abstract class AddBase(IItemNameRepository repository) : AddFeatureBase(repository)
    {
        protected override Task<ItemName> ConvertToEntity(AddItemNameRequest request, CancellationToken cancellationToken)
            => Task.FromResult(request.ToEntity());

        protected override Task<ItemNameDto> ConvertToDto(ItemName entity, CancellationToken cancellationToken)
            => Task.FromResult(entity.ToDto());
    }

    internal abstract class UpdateBase(IItemNameRepository repository) : UpdateFeatureBase(repository)
    {
        protected override Task PatchEntityAsync(ItemName entity, UpdateItemNameRequest request, CancellationToken cancellationToken)
        {
            entity.Patch(request);
            return Task.CompletedTask;
        }
    }

    internal abstract class DeleteBase(IItemNameRepository repository) : DeleteFeatureBase(repository);

    internal abstract class FindByIdBase(IItemNameRepository repository) : FindByIdFeatureBase(repository)
    {
        protected override Task<ItemNameDto> ConvertToDto(ItemName entity, CancellationToken cancellationToken)
            => Task.FromResult(entity.ToDto());
    }

    internal abstract class ListBase(IItemNameRepository repository) : ListFeatureBase(repository)
    {
        protected override Task<ItemNameDto> ConvertToDto(ItemName entity, CancellationToken cancellationToken)
            => Task.FromResult(entity.ToDto());
    }
}
