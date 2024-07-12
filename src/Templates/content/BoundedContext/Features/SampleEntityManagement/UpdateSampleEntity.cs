using Example.BoundedContext.Entities;
using Example.BoundedContext.Repositories.Abstractions;

namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IUpdateSampleEntity))]
internal class UpdateSampleEntity(ISampleEntityRepository repository, IMapper mapper) :
	GenericUpdateFeature<UpdateSampleEntityRequest, SampleEntity, ISampleEntityRepository, Guid>(repository, mapper),
	IUpdateSampleEntity
{
	protected override async Task CheckDuplicateAsync(Guid id, UpdateSampleEntityRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByNameAsync(request.Name, cancellationToken);

		if (entity != null && entity.Id != id)
			throw new AlreadyExistsException<SampleEntity>(request.Name);
	}
}
