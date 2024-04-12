using KamiSama.Repositories.EntityFramework.Histories;
using System.Data.Entity;

namespace KamiSama.Repositories.Tests.EF;

[TestClass]
public class EF_HistoricalDbRepositoryTests
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
	public void Add_must_add_to_dbSet_and_record_a_history_record()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext();

		var repository = new SampleHistorycalRepository<SampleEntity, SampleContext>(context);

		repository.Add(entity);

		CollectionAssert.Contains(context.SampleEntities.ToArray(), entity);
		Assert.IsNotNull(repository.LastHistoryItem);
		Assert.AreEqual(DbModificationType.Add, repository.LastHistoryItem!.ModificationType);
		Assert.AreEqual(entity, repository.LastHistoryItem!.Entity);
	}
	[TestMethod]
	public async Task AddAsync_must_add_to_dbSet_and_record_a_history_record()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext();

		var repository = new SampleHistorycalRepository<SampleEntity, SampleContext>(context);

		await (repository as IAsyncQueryableRepository<SampleEntity>).AddAsync(entity);

		CollectionAssert.Contains(context.SampleEntities.ToArray(), entity);
		Assert.IsNotNull(repository.LastHistoryItem);
		Assert.AreEqual(DbModificationType.Add, repository.LastHistoryItem!.ModificationType);
		Assert.AreEqual(entity, repository.LastHistoryItem!.Entity);
	}
	[TestMethod]
	public void Update_must_update_status_in_context_and_record_a_history_record()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);

		var repository = new SampleHistorycalRepository<SampleEntity, SampleContext>(context);

		repository.Update(entity);

		CollectionAssert.Contains(context.SampleEntities.ToArray(), entity);
		Assert.IsNotNull(repository.LastHistoryItem);
		Assert.AreEqual(DbModificationType.Update, repository.LastHistoryItem!.ModificationType);
		Assert.AreEqual(entity, repository.LastHistoryItem!.Entity);
	}
	[TestMethod]
	public async Task UpdateAsync_must_update_status_in_context_and_record_a_history_record()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);

		var repository = new SampleHistorycalRepository<SampleEntity, DbContext>(context);

		await (repository as IAsyncQueryableRepository<SampleEntity>).UpdateAsync(entity);

		Assert.AreEqual(EntityState.Unchanged, context.Entry(entity).State);
		Assert.IsNotNull(repository.LastHistoryItem);
		Assert.AreEqual(DbModificationType.Update, repository.LastHistoryItem!.ModificationType);
		Assert.AreEqual(entity, repository.LastHistoryItem!.Entity);
	}
	[TestMethod]
	public void Delete_must_remove_dbSet_and_record_a_history_record()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);

		var repository = new SampleHistorycalRepository<SampleEntity, SampleContext>(context);

		repository.Delete(entity);

		CollectionAssert.DoesNotContain(context.SampleEntities.ToArray(), entity);
		Assert.IsNotNull(repository.LastHistoryItem);
		Assert.AreEqual(DbModificationType.Delete, repository.LastHistoryItem!.ModificationType);
		Assert.AreEqual(entity, repository.LastHistoryItem!.Entity);
	}
	[TestMethod]
	public async Task DeleteAsync_must_remove_dbSet()
	{
		var entity = new SampleEntity { Id = 1, Name = "Test" };
		var context = GetDbContext(initialDbSet: [entity]);

		var repository = new SampleHistorycalRepository<SampleEntity, SampleContext>(context);

		await repository.DeleteAsync(entity, CancellationToken.None);

		CollectionAssert.DoesNotContain(context.SampleEntities.ToArray(), entity);
		Assert.IsNotNull(repository.LastHistoryItem);
		Assert.AreEqual(DbModificationType.Delete, repository.LastHistoryItem!.ModificationType);
		Assert.AreEqual(entity, repository.LastHistoryItem!.Entity);
	}
}
