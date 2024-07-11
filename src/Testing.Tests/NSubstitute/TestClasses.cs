using Microsoft.Testing.Platform.Logging;

namespace KamiSama.Testing.Tests.NSubstitute;

public class MyEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}

public interface IMyEntityRepository
{
    List<MyEntity> ListAll();

    MyEntity? FindByName(string name);
    MyEntity? FindById(Guid id);
}

public interface IMyDomainService
{
    void DoSomethingElse();
}

public class MyServiceToTest(IMyEntityRepository repository, IMyDomainService domainService, ILogger<MyServiceToTest> logger)
{
    public string DoSomething(Guid id)
    {
        var entity = repository.FindById(id);
        logger.LogInformation("Some logs.");
        domainService.DoSomethingElse();

        return entity!.Name;
    }
}