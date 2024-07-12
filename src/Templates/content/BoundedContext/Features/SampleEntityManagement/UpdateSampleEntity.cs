namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IUpdateSampleEntity))]
internal class UpdateSampleEntity(ISampleEntityRepository repository, IMapper mapper) 
	: GenericUpdateFeature<AddSampleEntityRequest, SampleEntity, ISampleEntityRepository>(repository, mapper), IUpdateSampleEntity
{
}
