using KamiSama.Repositories.EntityFramework;

namespace KamiSama.Repositories.Tests.EF;

[TestClass]
public class IQueryableExtensionsTests
{
	private static SampleContext GetDbContext()
	{
		var initialDbSet = new SampleEntity[13];
		var entities = new SampleEntity[13];

		for (int i = 0; i < entities.Length; i++)
			entities[i] = new SampleEntity { Id = i + 1, Name = $"Name {(i + 1)}" };

		var connection = Effort.DbConnectionFactory.CreateTransient();
		var context = new SampleContext(connection, true);

		context.SampleEntities.AddRange(entities);
		context.SaveChanges();

		return context;
	}
	[TestMethod]
	public async Task MakePagedAsync_returns_all_items_for_SearchModel_All()
	{
		var query = GetDbContext().SampleEntities.OrderBy(x => x.Id);

		var paged = await query.MakePagedAsync(SearchModel.All, CancellationToken.None);

		CollectionAssert.AreEqual(query.ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public async Task MakePagedAsync_returns_all_items()
	{
		var query = GetDbContext().SampleEntities.OrderBy(x => x.Id);

		var paged = await query.MakePagedAsync(SearchModel.FromPage(1, 0), CancellationToken.None);

		CollectionAssert.AreEqual(query.ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public async Task MakePagedAsync_returns_first_page_if_page_no_is_1()
	{
		var query = GetDbContext().SampleEntities.OrderBy(x => x.Id);

		var paged = await query.MakePagedAsync(SearchModel.FromPage(1, 10), CancellationToken.None);

		CollectionAssert.AreEqual(query.Take(10).ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public async Task MakePagedAsync_returns_first_page_if_page_no_is_2()
	{
		var query = GetDbContext().SampleEntities.OrderBy(x => x.Id);

		var paged = await query.MakePagedAsync(SearchModel.FromPage(2, 10), CancellationToken.None);

		CollectionAssert.AreEqual(query.Skip(10).Take(10).ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
}
