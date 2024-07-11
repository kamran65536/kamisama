using KamiSama.Testing.NSubstitute;
using NSubstitute;

namespace KamiSama.Testing.Tests.NSubstitute;
public class MyBuilder : TesterBuilderBase
{
    public MyEntity SampleEntity { get; }

    public MyBuilder()
    {
        SampleEntity = new MyEntity { Id = Guid.NewGuid(), Name = "Test" };
    }

    public IMyEntityRepository AddMyEntities(params MyEntity[] items)
    {
        var repository = base.AddScoped<IMyEntityRepository>();

        repository.ListAll().Returns([..items]);

        foreach (var item in items)
        {
            repository.FindById(item.Id).Returns(item);
            repository.FindByName(item.Name).Returns(item);
        }

        return repository;
    }
}
