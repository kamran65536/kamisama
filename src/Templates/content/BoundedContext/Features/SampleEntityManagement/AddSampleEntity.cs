namespace Project.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IAddSampleEntity))]
internal class AddSampleEntity(ISampleEntityRepository repository, IMapper mapper) : GenericAddFeature<AddSampleEntityRequest, SampleEntity, ISampleEntityRepository>(repository, mapper)
{
}
