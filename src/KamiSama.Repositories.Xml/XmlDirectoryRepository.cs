using KamiSama.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KamiSama.Repositories.Xml
{
	/// <summary>
	/// Json File Repository
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public class XmlDirectoryRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	{
		/// <summary>
		/// empty collection for queries
		/// </summary>
		private static readonly IQueryable<TEntity> Empty = (new TEntity[0]).AsQueryable();
		/// <summary>
		/// raised when loading items from file fails
		/// </summary>
		public event Action<XmlDirectoryRepository<TEntity>, Exception>? LoadFailed;
		/// <summary>
		/// raised when saving items to file fails
		/// </summary>
		public event Action<XmlDirectoryRepository<TEntity>, Exception>? SaveFailed;
		/// <summary>
		/// xml directory path
		/// </summary>
		private readonly string directoryPath;
		/// <summary>
		/// internal entities collection
		/// </summary>
		internal HashSet<TEntity>? entities;
		/// <summary>
		/// semaphore for concurrent scenarios
		/// </summary>
		private readonly SemaphoreSlim semaphore;
		/// <summary>
		/// equality comparer for HashSet
		/// </summary>
		private readonly IEqualityComparer<TEntity>? equalityComparer;
		/// <summary>
		/// 
		/// </summary>
		private readonly XmlSerializer serializer;
		/// <summary>
		/// a function to determine file names
		/// </summary>
		private readonly Func<TEntity, string> fileNameFunc;

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="filePath">path to json file as repository</param>
		/// <param name="equalityComparer"></param>
		/// <param name="serializer"></param>
		/// <param name="fileNameFunc"></param>
		public XmlDirectoryRepository(string filePath,
								Func<TEntity, string> fileNameFunc,
								XmlSerializer? serializer = null,
								IEqualityComparer<TEntity>? equalityComparer = null)
		{
			this.directoryPath = filePath;
			this.equalityComparer = equalityComparer;
			this.semaphore = new SemaphoreSlim(1);
			this.serializer = serializer ?? new XmlSerializer(typeof(TEntity[]));
			this.fileNameFunc = fileNameFunc;
		}
		/// <summary>
		/// loads the json file if not loaded already
		/// </summary>
		/// <returns></returns>
		public async Task<bool> TryLoadFileAsync(bool forceReload, CancellationToken cancellationToken = default)
		{
			if (forceReload)
				entities = null;

			if (entities != null)
				return true;
			await semaphore.WaitAsync(cancellationToken);
			if (entities != null)
			{
				semaphore.Release();
				return true;
			}

			try
			{
				var dir = new DirectoryInfo(directoryPath);
			
				var all = (equalityComparer == null) ? new HashSet<TEntity>() : new HashSet<TEntity>(equalityComparer);
				
				foreach (var file in dir.GetFiles("*.xml"))
				{
					var entity = (await File.ReadAllTextAsync(file.FullName, cancellationToken)).DeserializeFromXml<TEntity>(serializer);

					if (fileNameFunc(entity) != file.Name)
						throw new InvalidOperationException($"entity name {fileNameFunc(entity)} does not match file name: {file.Name}");

					all.Add(entity);
				}

				entities = all;

				return true;
			}
			catch (Exception exp)
			{
				LoadFailed?.Invoke(this, exp);

				return false;
			}
			finally
			{
				semaphore.Release();
			}
		}
		/// <summary>
		/// modifies (add,delete, update) the collection and saves the result into the file
		/// </summary>
		/// <param name="action"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		private async Task ModifyAndSaveToFileAsync(Action action, CancellationToken cancellationToken = default)
		{
			if (!await TryLoadFileAsync(false, cancellationToken))
				return;

			await semaphore.WaitAsync(cancellationToken);
			try
			{
				action();

				foreach (var entity in entities!)
				{
					await File.WriteAllTextAsync(directoryPath, entity!.SerializeToXml(), cancellationToken);
				}
			}
			catch (Exception exp)
			{
				SaveFailed?.Invoke(this, exp);
			}
			finally
			{
				semaphore.Release();
			}
		}
		/// <inheritdoc />
		public void Dispose()
		{
			try
			{
				entities?.Clear();
			}
			catch
			{
			}
		}
		/// <inheritdoc />
		public Task AddAsync(TEntity item, CancellationToken cancellationToken = default)
			=> ModifyAndSaveToFileAsync(() => entities!.Add(item), cancellationToken);
		/// <inheritdoc />
		public Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default)
			=> ModifyAndSaveToFileAsync(() => entities!.Remove(item), cancellationToken);
		/// <inheritdoc />
		public Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
			=> ModifyAndSaveToFileAsync(() => { }, cancellationToken);
		/// <inheritdoc />
		public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken = default)
		{
			if (!await TryLoadFileAsync(false, cancellationToken))
				return default;
			else if (predicate == null)
				return default;
			else
				return entities.FirstOrDefault(predicate.Compile());
		}
		/// <inheritdoc />
		public async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken = default)
		{
			if (!await TryLoadFileAsync(false, cancellationToken))
				return Empty;
			else if (predicate == null)
				return entities.AsQueryable();
			else
				return entities.Where(predicate.Compile()).AsQueryable();
		}
		/// <inheritdoc />
		public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null)
			=> WhereAsync(predicate, CancellationToken.None).Result;
		/// <inheritdoc />
		public void Add(TEntity item) => AddAsync(item, CancellationToken.None).Wait();
		/// <inheritdoc />
		public void Update(TEntity item) => UpdateAsync(item, CancellationToken.None).Wait();
		/// <inheritdoc />
		public void Delete(TEntity item) => DeleteAsync(item, CancellationToken.None).Wait();
		/// <inheritdoc />
		public TEntity? Find(Expression<Func<TEntity, bool>>? predicate = null) => FindAsync(predicate, CancellationToken.None).Result;
	}
}