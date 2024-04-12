using KamiSama.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Repositories.Tests.EFCore;

[TestClass]
public class IQueryableExtensionsTests
{
	private static readonly Random random = new();

	private static SampleContext GetDbContext(string? databaseName = null)
	{
		databaseName ??= ("SampleContext" + random.Next());

		var options = new DbContextOptionsBuilder<SampleContext>()
			.UseInMemoryDatabase(databaseName)
			.UseLazyLoadingProxies()
			.Options;

		var context = new SampleContext(options);

		var entities = new SampleEntity[13];

		for (int i = 0; i < entities.Length; i++)
			entities[i] = new SampleEntity { Id = i + 1, Name = $"Name {(i + 1)}" };


		context.SampleEntities.AddRange(entities);
		context.SaveChanges();

		return context;
	}
	[TestMethod]
	public async Task MakePagedAsync_returns_all_items_for_SearchModel_All()
	{
		var query = GetDbContext().SampleEntities;

		var paged = await query.MakePagedAsync(SearchModel.All, CancellationToken.None);

		CollectionAssert.AreEqual(query.ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public async Task MakePagedAsync_returns_all_items()
	{
		var query = GetDbContext().SampleEntities;

		var paged = await query.MakePagedAsync(SearchModel.FromPage(1, 0), CancellationToken.None);

		CollectionAssert.AreEqual(query.ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public async Task MakePagedAsync_returns_first_page_if_page_no_is_1()
	{
		var query = GetDbContext().SampleEntities;

		var paged = await query.MakePagedAsync(SearchModel.FromPage(1, 10), CancellationToken.None);

		CollectionAssert.AreEqual(query.Take(10).ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public async Task MakePagedAsync_returns_first_page_if_page_no_is_2()
	{
		var query = GetDbContext().SampleEntities;

		var paged = await query.MakePagedAsync(SearchModel.FromPage(2, 10), CancellationToken.None);

		CollectionAssert.AreEqual(query.Skip(10).Take(10).ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
}
