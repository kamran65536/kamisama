namespace KamiSama.Templates.content.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IFindSampleEntityByIdFeature))]
internal class FindSampleEntityById : GenericFindByIdFeature<SampleEntity, SampleEntityDto, ISampleEntityRepository, Guid>, IFindSampleEntityByIdFeature
{
}
