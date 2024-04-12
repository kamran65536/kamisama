using KamiSama.Repositories.EntityFramework.Histories;
using System.Data.Entity;

namespace KamiSama.Repositories.Tests.EF;

public class SampleHistorycalRepository<TEntity, TContext>(TContext context) : HistoricalDbRepository<TEntity, TContext>(context)
	where TEntity : class
	where TContext : DbContext
{
	public History<TEntity>? LastHistoryItem { get; private set; }

	protected override Task AddToHistoryRepositoryAsync(History<TEntity> historyItem, CancellationToken cancellationToken)
	{
		LastHistoryItem = historyItem;

		return Task.CompletedTask;
	}
}
