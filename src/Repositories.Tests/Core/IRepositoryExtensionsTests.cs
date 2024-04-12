namespace KamiSama.Repositories.Tests.Core;

[TestClass]
public class IRepositoryExtensionsTests
{
	[TestMethod]
	public void FirstOrDefault_must_call_FirstOrDefault_on_Where_method()
	{
		var sampleCollection = new [] { new SampleEntity()};
		Expression<Func<SampleEntity, bool>> predicate = se => true;

		var repository = Substitute.For<IQueryableRepository<SampleEntity>>();
		repository.Where(Arg.Any<Expression<Func<SampleEntity, bool>>>()).Returns(sampleCollection.AsQueryable());

		var result = repository.FirstOrDefault(predicate);

		Assert.AreEqual(sampleCollection[0], result);
		repository.Received().Where(predicate);
	}
	[TestMethod]
	public void GetAll_must_call_Where_method()
	{
		var sampleCollection = new[] { new SampleEntity() };
		Expression<Func<SampleEntity, bool>> predicate = se => true;

		var repository = Substitute.For<IQueryableRepository<SampleEntity>>();
		repository.Where(Arg.Any<Expression<Func<SampleEntity, bool>>>()).Returns(sampleCollection.AsQueryable());

		var result = repository.GetAll();

		CollectionAssert.AreEqual(sampleCollection, result.ToArray());
	}
}
