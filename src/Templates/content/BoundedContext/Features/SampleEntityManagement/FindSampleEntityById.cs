namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IFindSampleEntityById))]
internal class FindSampleEntityById(ISampleEntityRepository repository, IMapper mapper)
	: GenericFindByIdFeature<SampleEntity, SampleEntityDto, ISampleEntityRepository, Guid>(repository, mapper), IFindSampleEntityById
{
}
