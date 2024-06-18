using KamiSama.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.EntityFrameworkCore.Histories;

/// <summary>
/// Historical Db Repository, this db repository raises a method AddToHistoryRepositoryAsync to add a history record of the current one
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <param name="context"></param>
public abstract class HistoricalDbRepository<TEntity>(DbContext context)
    : DbRepository<TEntity>(context)
    where TEntity : class
{
    /// <summary>
    /// Adds entity to history repository
    /// </summary>
    /// <param name="historyItem">history item, including modification time and entity</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected abstract Task AddToHistoryRepositoryAsync(History<TEntity> historyItem, CancellationToken cancellationToken);
    /// <inheritdoc />
    public override void Add(TEntity item)
    {
        base.Add(item);

        AddToHistoryRepositoryAsync(History<TEntity>.CreateFrom(item, DbModificationType.Add), CancellationToken.None);
    }
    /// <inheritdoc />
    public override async Task AddAsync(TEntity item, CancellationToken cancellationToken)
    {
        await base.AddAsync(item, cancellationToken);

        await AddToHistoryRepositoryAsync(History<TEntity>.CreateFrom(item, DbModificationType.Add), cancellationToken);
    }
    /// <inheritdoc />
    public override void Update(TEntity item)
    {
        base.Update(item);

		AddToHistoryRepositoryAsync(History<TEntity>.CreateFrom(item, DbModificationType.Update), CancellationToken.None);
	}
    /// <inheritdoc />
	public override async Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
	{
		await base.UpdateAsync(item, cancellationToken);

        await AddToHistoryRepositoryAsync(History<TEntity>.CreateFrom(item, DbModificationType.Update), cancellationToken);
	}
    /// <inheritdoc />
	public override void Delete(TEntity item)
	{
		base.Delete(item);

		AddToHistoryRepositoryAsync(History<TEntity>.CreateFrom(item, DbModificationType.Delete), CancellationToken.None);
	}
    /// <inheritdoc />
	public override async Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
	{
		await base.DeleteAsync(item, cancellationToken);

        await AddToHistoryRepositoryAsync(History<TEntity>.CreateFrom(item, DbModificationType.Delete), cancellationToken);
	}
}

/// <summary>
/// Historical Db Repository, this db repository raises a method AddToHistoryRepositoryAsync to add a history record of the current one
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TDbContext"></typeparam>
/// <param name="context"></param>
public abstract class HistoricalDbRepository<TEntity, TDbContext>(TDbContext context) : HistoricalDbRepository<TEntity>(context)
    where TEntity : class
    where TDbContext : DbContext

{
	/// <summary>
	/// Inner Context
	/// </summary>
	protected new TDbContext Context => (TDbContext)base.Context;
}