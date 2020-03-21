using KamiSama.Repositories.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Tests.EF
{
	[TestClass]
	public class EF_DbRepositoryTests
	{
		[TestMethod]
		public void Add_must_add_to_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var dbSet = Substitute.For<DbSet<SampleEntity>>();
			var context = Substitute.For<SampleContext>();
			context.Set<SampleEntity>().Returns(dbSet);

			var repository = new DbRepository<SampleEntity>(context);

			repository.Add(entity);

			dbSet.Received().Add(entity);
			context.Received().SaveChanges();
		}
		[TestMethod]
		public async Task AddAsync_must_add_to_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var dbSet = Substitute.For<DbSet<SampleEntity>>();
			var context = Substitute.For<SampleContext>();
			context.Set<SampleEntity>().Returns(dbSet);

			var repository = new DbRepository<SampleEntity>(context);

			await repository.AddAsync(entity);

			dbSet.Received().Add(entity);
			await context.Received().SaveChangesAsync();
		}
		[TestMethod]
		public void Update_must_update_status_to_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var dbSet = Substitute.For<DbSet<SampleEntity>>();
			var context = Substitute.For<SampleContext>();
			context.Set<SampleEntity>().Returns(dbSet);

			var repository = new DbRepository<SampleEntity>(context);

			repository.Update(entity);

			context.Received().SaveChanges();
		}
		[TestMethod]
		public async Task UpdateAsync_must_update_status_to_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var dbSet = Substitute.For<DbSet<SampleEntity>>();
			var context = Substitute.For<SampleContext>();
			context.Set<SampleEntity>().Returns(dbSet);

			var repository = new DbRepository<SampleEntity>(context);

			await repository.UpdateAsync(entity);

			await context.Received().SaveChangesAsync();
		}
		[TestMethod]
		public void Delete_must_update_remove_from_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var dbSet = Substitute.For<DbSet<SampleEntity>>();
			var context = Substitute.For<SampleContext>();
			context.Set<SampleEntity>().Returns(dbSet);

			var repository = new DbRepository<SampleEntity>(context);

			repository.Delete(entity);

			dbSet.Received().Remove(entity);
			context.Received().SaveChanges();
		}
		[TestMethod]
		public async Task DeleteAsync_must_update_remove_from_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var dbSet = Substitute.For<DbSet<SampleEntity>>();
			var context = Substitute.For<SampleContext>();
			context.Set<SampleEntity>().Returns(dbSet);

			var repository = new DbRepository<SampleEntity>(context);

			await repository.DeleteAsync(entity);

			dbSet.Received().Remove(entity);
			await context.Received().SaveChangesAsync();
		}
		[TestMethod]
		public void Find_must_find_items_in_dbSet()
		{
			var entity = new SampleEntity { Id = 1, Name = "Test" };
			var query = new[] { entity }.AsQueryable();
			var dbSet = Substitute.For<DbSet<SampleEntity>, IQueryable<SampleEntity>>();
			var context = Substitute.For<SampleContext>();

			context.Set<SampleEntity>().Returns(dbSet);
			var queryableDbSet = dbSet as IQueryable<SampleEntity>;

			queryableDbSet.Provider.Returns(query.Provider);
			queryableDbSet.Expression.Returns(query.Expression);
			queryableDbSet.ElementType.Returns(query.ElementType);
			queryableDbSet.GetEnumerator().Returns(query.GetEnumerator());

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
			var query = new[] { entity }.AsQueryable();
			var dbSet = Substitute.For<DbSet<SampleEntity>, IQueryable<SampleEntity>>();
			var context = Substitute.For<SampleContext>();
			
			context.Set<SampleEntity>().Returns(dbSet);
			var queryableDbSet = dbSet as IQueryable<SampleEntity>;
			queryableDbSet.Provider.Returns(new SampleDbAsyncQueryProvider(query.Provider));
			queryableDbSet.Expression.Returns(query.Expression);
			queryableDbSet.ElementType.Returns(query.ElementType);
			queryableDbSet.GetEnumerator().Returns(query.GetEnumerator());

			var repository = new DbRepository<SampleEntity>(context);

			var result = await repository.FindAsync(x => x.Id == 1);
			Assert.AreEqual(entity, result);

			var result2 = repository.Find(x => x.Id == 2);
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
			var query = arr.AsQueryable();
			var dbSet = Substitute.For<DbSet<SampleEntity>, IQueryable<SampleEntity>>();
			var context = Substitute.For<SampleContext>();

			context.Set<SampleEntity>().Returns(dbSet);
			var queryableDbSet = dbSet as IQueryable<SampleEntity>;
			queryableDbSet.Provider.Returns(new SampleDbAsyncQueryProvider(query.Provider));
			queryableDbSet.Expression.Returns(query.Expression);
			queryableDbSet.ElementType.Returns(query.ElementType);
			queryableDbSet.GetEnumerator().Returns(query.GetEnumerator());

			var repository = new DbRepository<SampleEntity>(context);

			var result = repository.Where(x => x.Name.StartsWith("sample")).ToArray();

			CollectionAssert.Contains(result, arr[0]);
			CollectionAssert.Contains(result, arr[1]);
			CollectionAssert.DoesNotContain(result, arr[2]);
		}
	}
}
