namespace KamiSama.Testing.Tests.NSubstitute;

[TestClass]
public class BuilderTesterBaseTests
{
    /// <summary>
    /// All irelevant test items are removed
    /// </summary>
    [TestMethod]
    public void BuildService_must_build_correct_service()
    {
        var builder = new MyBuilder();

        builder.AddMyEntities(builder.SampleEntity);

        var service = builder.BuildService<MyServiceToTest>();

        var result = service.DoSomething(builder.SampleEntity.Id);

        Assert.AreEqual(builder.SampleEntity.Name, result);
    }
}