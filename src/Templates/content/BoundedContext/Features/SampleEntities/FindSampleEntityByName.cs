namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IFindSampleEntityByName))]
internal class FindSampleEntityByName(ISampleEntityRepository repository, IMapper mapper) :
	GenericFindByNameFeature<SampleEntity, SampleEntityDto, ISampleEntityRepository>(repository, mapper),
	IFindSampleEntityByName
{
}
