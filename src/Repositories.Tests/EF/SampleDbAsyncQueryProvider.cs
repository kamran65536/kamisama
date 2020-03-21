
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Tests.EF
{
	class SampleDbAsyncQueryProvider : IDbAsyncQueryProvider
	{
		private readonly IQueryProvider internalProvider;
		public SampleDbAsyncQueryProvider(IQueryProvider internalProvider)
		{
			this.internalProvider = internalProvider;
		}

		public IQueryable CreateQuery(Expression expression) => internalProvider.CreateQuery(expression);
		public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => internalProvider.CreateQuery<TElement>(expression);
		public object Execute(Expression expression) => internalProvider.Execute(expression);
		public TResult Execute<TResult>(Expression expression) => internalProvider.Execute<TResult>(expression);
		public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken) => Task.FromResult(internalProvider.Execute(expression));
		public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) => Task.FromResult(internalProvider.Execute<TResult>(expression));
	}
}
