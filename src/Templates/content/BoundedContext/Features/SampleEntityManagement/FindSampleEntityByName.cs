namespace KamiSama.Templates.content.BoundedContext.Features.SampleEntityManagement;

[AutoInjectScoped(typeof(IFindSampleEntityByNameFeature))]
internal class FindSampleEntityByName : GenericFindByNameFeature<SampleEntity, SampleEntityDto, ISampleEntityRepository>, IFindSampleEntityByNameFeature
{
}
