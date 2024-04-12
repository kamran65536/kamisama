using KamiSama.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Repositories.Tests.EFCore
{
	[TestClass]
	public class EFCore_DbRepositoryTests
	{
		private static readonly Random random = new();
		private static SampleContext GetDbContext(string? databaseName = null, SampleEntity[]? initialDbSet = null)
		{
			databaseName ??= ("SampleContext" + random.Next());
			
			var options = new DbContextOptionsBuilder<SampleContext>()
				.UseInMemoryDatabase(databaseName)
				.UseLazyLoadingProxies()
				.Options;

			var context = new SampleContext(options);

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

			Assert.IsTrue(context.SampleEntities.Any(x => x.Id == entity.Id && x.Name == entity.Name));
		}
		[TestMethod]
		public async Task AddAsync_must_add_to_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext();

			var repository = new DbRepository<SampleEntity>(context);

			await repository.AddAsync(entity, CancellationToken.None);

			Assert.IsTrue(context.SampleEntities.Any(x => x.Id == entity.Id && x.Name == entity.Name));
		}
		[TestMethod]
		public void Update_must_update_status_in_context()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: [entity]);

			var repository = new DbRepository<SampleEntity>(context);

			Assert.IsTrue(context.SampleEntities.Any(x => x.Id == entity.Id && x.Name == entity.Name));

			repository.Update(entity);
		
			Assert.IsTrue(context.SampleEntities.Any(x => x.Id == entity.Id && x.Name == "Test"));
		}
		[TestMethod]
		public async Task UpdateAsync_must_update_status_in_context()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: [entity]);

			var repository = new DbRepository<SampleEntity>(context);

			Assert.IsTrue(context.SampleEntities.Any(x => x.Id == entity.Id && x.Name == entity.Name));

			await repository.UpdateAsync(entity);

			Assert.IsTrue(context.SampleEntities.Any(x => x.Id == entity.Id && x.Name == "Test"));
		}
		[TestMethod]
		public void Delete_must_remove_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: [entity]);

			var repository = new DbRepository<SampleEntity>(context);

			Assert.IsTrue(context.SampleEntities.Contains(entity));

			repository.Delete(entity);

			Assert.IsFalse(context.SampleEntities.Contains(entity));
		}
		[TestMethod]
		public async Task DeleteAsync_must_remove_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: [entity]);

			var repository = new DbRepository<SampleEntity>(context);

			Assert.IsTrue(context.SampleEntities.Contains(entity));

			await repository.DeleteAsync(entity);

			Assert.IsFalse(context.SampleEntities.Contains(entity));
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
	}
}
