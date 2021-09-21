using KamiSama.Repositories.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Tests.Core
{
	[TestClass]
	public class JsonRepositoryTests
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
		public void Ctor_must_initialize_repository_using_given_filePath()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");

			var all = repository.GetAll();

			Assert.IsTrue(all.Any(x => x.Id == 1 && x.Name == "item1"));
			Assert.IsTrue(all.Any(x => x.Id == 11 && x.Name == "item11"));
		}
		[TestMethod]
		public void Ctor_must_initialize_empty_repository_if_filePath_is_invalid()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/invalid-file-path.json");

			Assert.AreEqual(0, repository.GetAll().Count());
		}
		[TestMethod]
		public void Ctor_must_use_given_comparer_function()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json", new Module10EntityComparer());
			var all = repository.GetAll();

			Assert.IsTrue(all.Any(x => x.Id == 1 && x.Name == "item1"));
			Assert.IsFalse(all.Any(x => x.Id == 11 && x.Name == "item11"));
			Assert.IsTrue(all.Any(x => x.Id == 22 && x.Name == "--not-found"));
		}
		[TestMethod]
		public void Dispose_releases_items_in_repository()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");
			repository.TryLoadFileAsync(forceReload: true, CancellationToken.None).Wait();

			repository.Dispose();

			Assert.AreEqual(0, repository.entities?.Count());
		}
		[TestMethod]
		public void Add_must_add_new_item_to_repository()
		{
			var tempFileName = Path.GetTempFileName();

			File.Copy("./Json/sample-entities.json", tempFileName, true);
			var repository = new JsonRepository<SampleEntity>(tempFileName);

			repository.Add(new SampleEntity { Id = 333, Name = "item333" });

			Assert.IsNotNull(repository.Find(x => x.Id == 333 && x.Name == "item333"));

			File.Delete(tempFileName);
		}
		[TestMethod]
		public void Update_saves_item_into_the_file()
		{
			var tempFileName = Path.GetTempFileName();

			File.Copy("./Json/sample-entities.json", tempFileName, true);
			var repository = new JsonRepository<SampleEntity>(tempFileName);

			var sample = repository.FirstOrDefault(x => x.Name == "item1");

			sample.Name = "item111";
			repository.Update(sample);

			repository.TryLoadFileAsync(forceReload: true, CancellationToken.None).Wait();

			Assert.IsFalse(repository.GetAll().Any(x => x.Name == "item1"));
			Assert.IsTrue(repository.GetAll().Any(x => x.Name == "item111"));

			File.Delete(tempFileName);
		}
		[TestMethod]
		public void Delete_removes_an_item_from_repository()
		{
			var tempFileName = Path.GetTempFileName();
			File.Copy("./Json/sample-entities.json", tempFileName, true);
			var repository = new JsonRepository<SampleEntity>(tempFileName);

			var item = repository.Find(x => x.Id == 1);
			repository.Delete(item);

			Assert.IsNull(repository.Find(x => x.Id == 1));

			File.Delete(tempFileName);
		}
		[TestMethod]
		public async Task AddAsync_must_add_new_item_to_repository()
		{
			var tempFileName = Path.GetTempFileName();

			File.Copy("./Json/sample-entities.json", tempFileName, true);
			var repository = new JsonRepository<SampleEntity>(tempFileName);

			await repository.AddAsync(new SampleEntity { Id = 333, Name = "item333" }, CancellationToken.None);

			Assert.IsNotNull(repository.Find(x => x.Id == 333 && x.Name == "item333"));

			File.Delete(tempFileName);
		}
		[TestMethod]
		public async Task UpdateAsync_saves_item_into_the_file()
		{
			var tempFileName = Path.GetTempFileName();

			File.Copy("./Json/sample-entities.json", tempFileName, true);
			var repository = new JsonRepository<SampleEntity>(tempFileName);

			var sample = repository.FirstOrDefault(x => x.Name == "item1");

			sample.Name = "item111";
			await repository.UpdateAsync(sample, CancellationToken.None);

			repository.TryLoadFileAsync(forceReload: true, CancellationToken.None).Wait();

			Assert.IsFalse(repository.GetAll().Any(x => x.Name == "item1"));
			Assert.IsTrue(repository.GetAll().Any(x => x.Name == "item111"));

			File.Delete(tempFileName);
		}
		[TestMethod]
		public async Task DeleteAsync_removes_an_item_from_repository()
		{
			var tempFileName = Path.GetTempFileName();
			File.Copy("./Json/sample-entities.json", tempFileName, true);
			var repository = new JsonRepository<SampleEntity>(tempFileName);

			var item = repository.Find(x => x.Id == 1);
			await repository.DeleteAsync(item, CancellationToken.None);

			Assert.IsNull(repository.Find(x => x.Id == 1));

			File.Delete(tempFileName);
		}
		[TestMethod]
		public void Find_must_return_an_item_with_specified_predicate()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");

			Assert.IsNotNull(repository.Find(x => x.Id == 1 && x.Name == "item1"));
		}
		[TestMethod]
		public void Find_must_return_null_if_none_matches_the_predicate()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");

			Assert.IsNull(repository.Find(x => x.Id == 1 && x.Name == "item1333"));
		}
		[TestMethod]
		public void Find_must_return_null_if_predicate_is_null()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");
			
			Assert.IsNull(repository.Find(null));
		}
		[TestMethod]
		public async Task FindAsync_must_return_an_item_with_specified_predicate()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");

			Assert.IsNotNull(await repository.FindAsync(x => x.Id == 1 && x.Name == "item1", CancellationToken.None));
		}
		[TestMethod]
		public async Task FindAsync_must_return_null_if_none_matches_the_predicate()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");

			Assert.IsNull(await repository.FindAsync(x => x.Id == 1 && x.Name == "item1444", CancellationToken.None));
		}
		[TestMethod]
		public async Task FindAsync_must_return_null_if_predicate_is_null()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");

			Assert.IsNull(await repository.FindAsync(null, CancellationToken.None));
		}
		[TestMethod]
		public void Where_must_return_items_that_matches_the_predicate()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json"); 

			var result = repository.Where(x => x.Name.StartsWith("item")).ToArray();

			Assert.IsTrue(result.Any(x => x.Name == "item1"));
			Assert.IsTrue(result.Any(x => x.Name == "item11"));
			Assert.IsFalse(result.Any(x => x.Name == "--not-found"));
		}
		[TestMethod]
		public void Where_must_return_all_items_if_predicate_is_null()
		{
			var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");

			var result = repository.Where(null).ToArray();

			Assert.IsTrue(result.Any(x => x.Name == "item1"));
			Assert.IsTrue(result.Any(x => x.Name == "item11"));
			Assert.IsTrue(result.Any(x => x.Name == "--not-found"));
		}
	}
}
