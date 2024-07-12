namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IAddSampleEntity))]
internal class AddSampleEntity(ISampleEntityRepository repository, IMapper mapper) :
	GenericAddFeature<AddSampleEntityRequest, SampleEntity, ISampleEntityRepository>(repository, mapper),
	IAddSampleEntity
{
	protected override async Task CheckDuplicateAsync(AddSampleEntityRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByNameAsync(request.Name, cancellationToken);

		if (entity != null)
			throw new AlreadyExistsException<SampleEntity>(request.Name);
	}
}
