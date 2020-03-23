using KamiSama.Repositories.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Tests.EF
{
	[TestClass]
	public class EF_DbRepositoryTests
	{
		private static SampleContext GetDbContext(SampleEntity[] initialDbSet = null)
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

			var repository = new DbRepository<SampleEntity>(context);

			await repository.AddAsync(entity);

			CollectionAssert.Contains(context.SampleEntities.ToArray(), entity);
		}
		[TestMethod]
		public void Update_must_update_status_in_context()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: new[] { entity });

			var repository = new DbRepository<SampleEntity>(context);

			repository.Update(entity);

			CollectionAssert.Contains(context.SampleEntities.ToArray(), entity);
		}
		[TestMethod]
		public async Task UpdateAsync_must_update_status_in_context()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: new[] { entity });

			var repository = new DbRepository<SampleEntity>(context);

			await repository.UpdateAsync(entity);

			Assert.AreEqual(EntityState.Unchanged, context.Entry(entity).State);
		}
		[TestMethod]
		public void Delete_must_remove_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: new[] { entity });

			var repository = new DbRepository<SampleEntity>(context);

			repository.Delete(entity);

			CollectionAssert.DoesNotContain(context.SampleEntities.ToArray(), entity);
		}
		[TestMethod]
		public async Task DeleteAsync_must_remove_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: new[] { entity });

			var repository = new DbRepository<SampleEntity>(context);

			await repository.DeleteAsync(entity);

			CollectionAssert.DoesNotContain(context.SampleEntities.ToArray(), entity);
		}
		[TestMethod]
		public void Find_must_find_items_in_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var context = GetDbContext(initialDbSet: new[] { entity });
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
			var context = GetDbContext(initialDbSet: new[] { entity });
			var repository = new DbRepository<SampleEntity>(context);

			var result = await repository.FindAsync(x => x.Id == 1);
			Assert.AreEqual(entity, result);

			var result2 = await repository.FindAsync(x => x.Id == 2);
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

			var result = repository.Where(x => x.Name.StartsWith("sample")).ToArray();

			CollectionAssert.Contains(result, arr[0]);
			CollectionAssert.Contains(result, arr[1]);
			CollectionAssert.DoesNotContain(result, arr[2]);
		}
	}
}
