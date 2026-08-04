# 9. KamiSama.Testing class Library
This library helps you to implement a bit cleaner tests using NSubstitute.
## 9.1 Old Approach
The common test (using MSTest and NSubstitute for example) would be something like this:
```csharp
	[TestMethod]
	public void TestSomething()
	{
		var id = Guid.NewGuid();
		var repo = Substitute.For<ISomeEntityRepository>();

		repo.FindByName("some-name").Returns(new SomeEntity
		{
			Id = id,
			Name = "some-name"
		});

		var someOtherService = Substitute.For<IMyDomainService>(); //irrelevant service
		var logger = Substitue.For<ILogger<MyServiceToTest>>();

		var serviceToTest = new MyServiceToTest(repo, someOtherService, logger);

		serviceToTest.DoSomething(id);

		//Assert some result here
	}
```
You need to write lots of code to initialize objects which are not really related to the code your testing.

## 9.2 KamiSama.Testing.* Approach

The you should implement a builder class for your test as the following:
```csharp
public class Builder : TesterBuilderBase
{
	public ISomeEntityRepository AddSomeEntitites(params SomeEntity[] items)
	{
		var id = Guid.NewGuid();
		var repo = base.AddScoped<ISomeEntityRepository>();

		repo.ListAll().Returns(itmes); // some list methods

		foreach (var item in items)
		{
			repo.FindByName(item.Name).Returns(item);
		}

		return repo;
	}
}
```

The new look would be:
```csharp
	[TestMethod]
	public void TestSomething()
	{
		var id = Guid.NewGuid();
		var builder = new TesterBuilder();//inherits the TesterBuilderBase

		builder.AddSomeEntities(new SomeEntity { Name = "some-name" });

		var serviceToTest = builder.BuildService<MyServiceToTest>();

		serviceToTest.DoSomething(id);

		//Assert some result here
	}
```

as you see, you only write the code which you are __actually testing__.

__Note__ that you should call builder.BuildService in order to build dependencies and use service.