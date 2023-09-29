using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Tests.Core
{
	[TestClass]
	public class InMemoryRepositoryTests
	{
		class Module10EntityComparer : IEqualityComparer<SampleEntity>
		{
			public bool Equals([AllowNull] SampleEntity x, [AllowNull] SampleEntity y)
				=> x.Id - y.Id % 10 == 0;
			public int GetHashCode([DisallowNull] SampleEntity obj)
			{
				return obj.Id % 10;
			}
		}
		[TestMethod]
		public void Ctor_must_initialize_repository_using_given_initialItems()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 2 },
				new SampleEntity { Id = 1 }
			};

			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			CollectionAssert.AreEqual(initialItems, repository.GetAll().ToArray());
		}
		[TestMethod]
		public void Ctor_must_initialize_empty_repository_if_initialItems_are_null()
		{
			var repository = new InMemoryRepository<SampleEntity>();

			Assert.AreEqual(0, repository.GetAll().Count());
		}
		[TestMethod]
		public void Ctor_must_use_given_comparer_function()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 11 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems, new Module10EntityComparer());

			Assert.AreEqual(1, repository.GetAll().Count());
		}
		[TestMethod]
		public void Dispose_releases_items_in_repository()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			((System.IDisposable)repository).Dispose();

			Assert.AreEqual(0, repository.GetAll().Count());
		}
		[TestMethod]
		public void Add_must_add_new_item_to_repository()
		{
			var sample = new SampleEntity { Id = 1, Name = "sample" };
			var repository = new InMemoryRepository<SampleEntity>();

			repository.Add(sample);

			Assert.AreEqual(sample, repository.FirstOrDefault(x => true));
		}
		[TestMethod]
		public void Update_does_nothing()
		{
			var sample = new SampleEntity { Id = 1, Name = "sample" };
			var repository = new InMemoryRepository<SampleEntity>(new[] { sample });

			sample.Name = "sample2";

			repository.Update(sample);

			var retrieved = repository.Find(x => x.Name == "sample2");

			Assert.AreEqual(sample, retrieved);
		}
		[TestMethod]
		public void Delete_removes_an_item_from_repository()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			repository.Delete(initialItems[0]);

			Assert.IsNull(repository.Find(x => x.Id == 1));
		}
		[TestMethod]
		public async Task AddAsync_must_add_new_item_to_repository()
		{
			var sample = new SampleEntity { Id = 1, Name = "sample" };
			var repository = new InMemoryRepository<SampleEntity>();

			await repository.AddAsync(sample, CancellationToken.None);

			Assert.AreEqual(sample, repository.FirstOrDefault(x => true));
		}
		[TestMethod]
		public async Task UpdateAsync_does_nothing()
		{
			var sample = new SampleEntity { Id = 1, Name = "sample" };
			var repository = new InMemoryRepository<SampleEntity>(new[] { sample });

			sample.Name = "sample2";

			await repository.UpdateAsync(sample, CancellationToken.None);

			var retrieved = repository.Find(x => x.Name == "sample2");

			Assert.AreEqual(sample, retrieved);
		}
		[TestMethod]
		public async Task DeleteAsync_removes_an_item_from_repository()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			await repository.DeleteAsync(initialItems[0], CancellationToken.None);

			Assert.IsNull(repository.Find(x => x.Id == 1));
		}
		[TestMethod]
		public void Find_must_return_an_item_with_specified_predicate()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			var result = repository.Find(x => x.Id == 2);

			Assert.AreEqual(initialItems[1], result);
		}
		[TestMethod]
		public void Find_must_return_null_if_none_matches_the_predicate()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			var result = repository.Find(x => x.Id == 3);

			Assert.IsNull(result);
		}
		[TestMethod]
		public void Find_must_return_null_if_predicate_is_null()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			var result = repository.Find(null);

			Assert.IsNull(result);
		}
		[TestMethod]
		public async Task FindAsync_must_return_an_item_with_specified_predicate()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			var result = await repository.FindAsync(x => x.Id == 2, CancellationToken.None);

			Assert.AreEqual(initialItems[1], result);
		}
		[TestMethod]
		public async Task FindAsync_must_return_null_if_none_matches_the_predicate()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			var result = await repository.FindAsync(x => x.Id == 3, CancellationToken.None);

			Assert.IsNull(result);
		}
		[TestMethod]
		public async Task FindAsync_must_return_null_if_predicate_is_null()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1 },
				new SampleEntity { Id = 2 }
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			var result = await repository.FindAsync(null, CancellationToken.None);

			Assert.IsNull(result);
		}
		[TestMethod]
		public void Where_must_return_items_that_matches_the_predicate()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1, Name = "sample1" },
				new SampleEntity { Id = 2, Name = "sample2" },
				new SampleEntity { Id = 2, Name = "-not-found" },
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			var result = repository.Where(x => x.Name.StartsWith("sample")).ToArray();

			CollectionAssert.Contains(result, initialItems[0]);
			CollectionAssert.Contains(result, initialItems[1]);
			CollectionAssert.DoesNotContain(result, initialItems[2]);
		}
		[TestMethod]
		public void Where_must_return_all_items_if_predicate_is_null()
		{
			var initialItems = new[] {
				new SampleEntity { Id = 1, Name = "sample1" },
				new SampleEntity { Id = 2, Name = "sample2" },
				new SampleEntity { Id = 2, Name = "-not-found" },
			};
			var repository = new InMemoryRepository<SampleEntity>(initialItems);

			var result = repository.Where(null).ToArray();

			CollectionAssert.Contains(result, initialItems[0]);
			CollectionAssert.Contains(result, initialItems[1]);
			CollectionAssert.Contains(result, initialItems[2]);
		}
	}
}
