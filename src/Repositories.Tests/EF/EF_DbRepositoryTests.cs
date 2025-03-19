using KamiSama.Repositories.EntityFramework;
using System.Data.Entity;

namespace KamiSama.Repositories.Tests.EF;

[TestClass]
public class EF_DbRepositoryTests
{
	private static SampleContext GetDbContext(SampleEntity[]? initialDbSet = null)
	{
		var connection = Effort.DbConnectionFactory.CreateTransient();
		var context = new SampleContext(connection, true);

		if (initialDbSet != null)
		{
			context.SampleEntities.AddRange(initialDbSet);
			context.SaveChanges();
		}

		return context;
	}
	[TestMethod]
	public void Add_must_add_to_dbSet()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext();

		var repository = new DbRepository<SampleEntity>(context);

		repository.Add(entity);

		CollectionAssert.Contains(context.SampleEntities.ToArray(), entity);
	}
	[TestMethod]
	public async Task AddAsync_must_add_to_dbSet()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext();

		var repository = new DbRepository<SampleEntity>(context) as IAsyncQueryableRepository<SampleEntity>;

		await repository.AddAsync(entity, CancellationToken.None);

		CollectionAssert.Contains(context.SampleEntities.ToArray(), entity);
	}
	[TestMethod]
	public void Update_must_update_status_in_context()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);

		var repository = new DbRepository<SampleEntity>(context);

		repository.Update(entity);

		CollectionAssert.Contains(context.SampleEntities.ToArray(), entity);
	}
	[TestMethod]
	public async Task UpdateAsync_must_update_status_in_context()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);

		var repository = new DbRepository<SampleEntity>(context) as IAsyncQueryableRepository<SampleEntity>;

		await repository.UpdateAsync(entity, CancellationToken.None);

		Assert.AreEqual(EntityState.Unchanged, context.Entry(entity).State);
	}
	[TestMethod]
	public void Delete_must_remove_dbSet()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);

		var repository = new DbRepository<SampleEntity>(context);

		repository.Delete(entity);

		CollectionAssert.DoesNotContain(context.SampleEntities.ToArray(), entity);
	}
	[TestMethod]
	public async Task DeleteAsync_must_remove_dbSet()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);

		var repository = new DbRepository<SampleEntity>(context);

		await repository.DeleteAsync(entity, CancellationToken.None);

		CollectionAssert.DoesNotContain(context.SampleEntities.ToArray(), entity);
	}
	[TestMethod]
	public void Find_must_find_items_in_dbSet()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);
		var repository = new DbRepository<SampleEntity>(context);

		var result = repository.Find(x => x.Id == 1);
		Assert.AreEqual(entity, result);

		var result2 = repository.Find(x => x.Id == 2);
		Assert.IsNull(result2);
	}
	[TestMethod]
	public async Task FindAsync_must_find_items_in_dbSet()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);
		var repository = new DbRepository<SampleEntity>(context);

		var result = await repository.FindAsync(x => x.Id == 1, CancellationToken.None);
		Assert.AreEqual(entity, result);

		var result2 = await repository.FindAsync(x => x.Id == 2, CancellationToken.None);
		Assert.IsNull(result2);
	}
	[TestMethod]
	public void Where_must_find_items_in_dbSet()
	{
		var arr = new[]
		{
			new SampleEntity { Id = 1, Name = "sample1" },
			new SampleEntity { Id = 2, Name = "sample2" },
			new SampleEntity { Id = 3, Name = "-not-found" }
		};
		var context = GetDbContext(initialDbSet: arr);
		var repository = new DbRepository<SampleEntity>(context);

		var result = repository.Where(x => x.Name!.StartsWith("sample")).ToArray();

		CollectionAssert.Contains(result, arr[0]);
		CollectionAssert.Contains(result, arr[1]);
		CollectionAssert.DoesNotContain(result, arr[2]);
	}
	[TestMethod]
	public void AsQueryable_returns_dbset_as_queryable()
	{
		var arr = new[]
		{
			new SampleEntity { Id = 1, Name = "sample1" },
			new SampleEntity { Id = 2, Name = "sample2" },
			new SampleEntity { Id = 3, Name = "-not-found" }
		};
		var context = GetDbContext(initialDbSet: arr);
		var repository = new DbRepository<SampleEntity>(context);

		var queryable = repository.AsQueryable();

		CollectionAssert.AreEquivalent(arr, queryable.ToArray());
	}
	[TestMethod]
	public void AsQueryable_Any_checks_if_entity_exists_in_repository_or_not()
	{
		var arr = new[]
		{
			new SampleEntity { Id = 1, Name = "sample1" },
			new SampleEntity { Id = 2, Name = "sample2" },
		};
		var context = GetDbContext(initialDbSet: arr);
		var repository = new DbRepository<SampleEntity>(context);

		Assert.IsTrue(repository.Any(x => x.Name == "sample1"));
		Assert.IsFalse(repository.Any(x => x.Name == "--not-found"));
	}
	[TestMethod]
	public async Task AsQueryable_AnyAsync_checks_if_entity_exists_in_repository_or_not()
	{
		var arr = new[]
		{
			new SampleEntity { Id = 1, Name = "sample1" },
			new SampleEntity { Id = 2, Name = "sample2" },
		};
		var context = GetDbContext(initialDbSet: arr);
		var repository = new DbRepository<SampleEntity>(context);

		Assert.IsTrue(await repository.AnyAsync(x => x.Name == "sample1", CancellationToken.None));
		Assert.IsFalse(await repository.AnyAsync(x => x.Name == "--not-found", CancellationToken.None));
	}
}
