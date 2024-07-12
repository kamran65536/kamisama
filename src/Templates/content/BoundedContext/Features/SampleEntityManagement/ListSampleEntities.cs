namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IListSampleEntities))]
internal class ListSampleEntities(ISampleEntityRepository repository, IMapper mapper) :
	GenericListFeature<SampleEntity, SampleEntityDto, SampleEntitySearchModel, ISampleEntityRepository>(repository, mapper),
	IListSampleEntities
{
}
