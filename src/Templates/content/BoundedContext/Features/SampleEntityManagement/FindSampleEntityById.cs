namespace KamiSama.Templates.content.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IFindSampleEntityById))]
internal class FindSampleEntityById : GenericFindByIdFeature<SampleEntity, SampleEntityDto, ISampleEntityRepository, Guid>, IFindSampleEntityById
{
}
