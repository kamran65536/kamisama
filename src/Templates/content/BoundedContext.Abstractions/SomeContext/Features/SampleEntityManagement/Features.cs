namespace Example.SomeContext.Features.SampleEntityManagement;

public interface IAddSampleEntity : IAddFeature<AddSampleEntityRequest>
{
}
public interface IUpdateSampleEntity : IUpdateFeature<UpdateSampleEntityRequest, Guid>
{
}
public interface IDeleteSampleEntity : IDeleteFeature<Guid>
{
}
public interface IListSampleEntity : IListFeature<SampleEntityDto, SampleEntitySearchModel>
{
}
public interface IFindSampleEntityByName : IFindByNameFeature<SampleEntityDto>
{
}