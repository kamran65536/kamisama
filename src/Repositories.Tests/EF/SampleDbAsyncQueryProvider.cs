using System.Data.Entity.Infrastructure;

namespace KamiSama.Repositories.Tests.EF;

class SampleDbAsyncQueryProvider(IQueryProvider internalProvider) : IDbAsyncQueryProvider
{
	private readonly IQueryProvider internalProvider = internalProvider;

	public IQueryable CreateQuery(Expression expression) => internalProvider.CreateQuery(expression);
	public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => internalProvider.CreateQuery<TElement>(expression);
	public object? Execute(Expression expression) => internalProvider.Execute(expression);
	public TResult Execute<TResult>(Expression expression) => internalProvider.Execute<TResult>(expression);
	public Task<object?> ExecuteAsync(Expression expression, CancellationToken cancellationToken = default) => Task.FromResult(internalProvider.Execute(expression));
	public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default) => Task.FromResult(internalProvider.Execute<TResult>(expression));
}
