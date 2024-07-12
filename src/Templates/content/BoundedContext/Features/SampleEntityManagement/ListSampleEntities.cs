namespace Example.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IListSampleEntities))]
internal class AddSampleEntity(ISampleEntityRepository repository, IMapper mapper) 
	: GenericListFeature<SampleEntity, SampleEntityDto, ISampleEntityRepository>(repository, mapper), IListSampleEnttiies, IFindByIdRepository<SampleEntity, Guid>, IFindByNameRepository<SampleEntity>
{
}
