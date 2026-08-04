using KamiSama.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.Repositories.EntityFrameworkCore;

internal class MultiProviderDbContextBuilder<TBaseContext>(
	IServiceCollection services,
	ConnectionStringOption connectionStringOption) : IMultiProviderDbContextBuilder<TBaseContext>
	where TBaseContext : DbContext
{
	public IServiceCollection Services => services;

	public ConnectionStringOption ConnectionStringOption => connectionStringOption;

	public string MigrationHistoryTable { get; set; } = $"{typeof(TBaseContext).Name}_History";

	public Type BaseContextType => typeof(TBaseContext);
}
