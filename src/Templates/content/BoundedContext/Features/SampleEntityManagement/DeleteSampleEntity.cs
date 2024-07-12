namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IDeleteSampleEntity))]
internal class DeleteSampleEntity(ISampleEntityRepository repository, IMapper mapper) 
	: GenericDeleteFeature<AddSampleEntityRequest, SampleEntity, ISampleEntityRepository>(repository, mapper), IDeleteSampleEntity
{
}
