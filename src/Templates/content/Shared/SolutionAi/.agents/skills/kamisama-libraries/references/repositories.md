# Repositories Snapshot

- `KamiSama.Repositories`: `IRepository<TEntity>`, `IAsyncRepository<TEntity>`, queryable repository contracts, `InMemoryRepository<TEntity>`, and `ConnectionStringOption`.
- `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity, TDbContext>`: EF Core CRUD and query wrapper.
- `KamiSama.Repositories.EntityFrameworkCore.IQueryableExtensions.MakePagedAsync`: async paging to `PagedResult<T>`.
- `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`: opt-in migration and seed hooks.
- `KamiSama.Repositories.Json.JsonRepository<TEntity>` and `KamiSama.Repositories.Xml` repositories: file-backed stores with load/save failure events.

For chassis applications, prefer the generic repository contracts and base in `chassis-and-features.md`. Keep provider migrations in provider projects and never enable migration or test-data initialization by default.
