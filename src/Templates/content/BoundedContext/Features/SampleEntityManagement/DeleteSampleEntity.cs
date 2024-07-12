namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IDeleteSampleEntity))]
internal class DeleteSampleEntity(ISampleEntityRepository repository) :
	GenericDeleteFeature<SampleEntity, ISampleEntityRepository, Guid>(repository), IDeleteSampleEntity
{
}
