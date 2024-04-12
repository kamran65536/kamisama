namespace KamiSama.Extensions.Core.Tests;

[TestClass]
public class IQueryableExtensionsTests
{
	private static IQueryable<int> GetCollection()
	{
#pragma warning disable CA1861 // Avoid constant arrays as arguments
		return (new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }).AsQueryable();
#pragma warning restore CA1861 // Avoid constant arrays as arguments
	}
	[TestMethod]
	public void MakePaged_returns_all_items_for_SearchModel_All()
	{
		var query = GetCollection();

		var paged = query.MakePaged(SearchModel.All);

		CollectionAssert.AreEqual(query.ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public void MakePaged_returns_all_items()
	{
		var query = GetCollection();

		var paged = query.MakePaged(SearchModel.FromPage(1, 0));

		CollectionAssert.AreEqual(query.ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public void MakePaged_returns_first_page_if_page_no_is_1()
	{
		var query = GetCollection();

		var paged = query.MakePaged(SearchModel.FromPage(1, 10));

		CollectionAssert.AreEqual(query.Take(10).ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
	[TestMethod]
	public void MakePaged_returns_first_page_if_page_no_is_2()
	{
		var query = GetCollection();

		var paged = query.MakePaged(SearchModel.FromPage(2, 10));

		CollectionAssert.AreEqual(query.Skip(10).Take(10).ToArray(), paged.Items);
		Assert.AreEqual(query.Count(), paged.TotalItemsCount);
	}
}
