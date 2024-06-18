using KamiSama.Repositories.EntityFramework.Histories;
using System.Data.Entity;

namespace KamiSama.Repositories.Tests.EF;

public class SampleHistorycalRepository<TEntity, TContext>(TContext context) : KamiSama.Repositories.EntityFramework.Histories.HistoricalDbRepository<TEntity, TContext>(context)
	where TEntity : class
	where TContext : DbContext
{
	public KamiSama.Repositories.EntityFramework.Histories.History<TEntity>? LastHistoryItem { get; private set; }

	protected override Task AddToHistoryRepositoryAsync(KamiSama.Repositories.EntityFramework.Histories.History<TEntity> historyItem, CancellationToken cancellationToken)
	{
		LastHistoryItem = historyItem;

		return Task.CompletedTask;
	}
}
