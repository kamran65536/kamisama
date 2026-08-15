# KamiSama.Repositories.EntityFrameworkCore.Initialization

[Back to KamiSama.Repositories.EntityFrameworkCore](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [DatabaseInitializerBase<TDbContext>](kamisama-repositories-entityframeworkcore-initialization-databaseinitializerbase-tdbcontext/index.md) | Class | Runs selected migration, application-data, and test-data stages sequentially for an EF Core context. Derived initializers implement both seed hooks and can use `TryAdd` for immediate conditional persistence. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L14) |
| [DefaultDatabaseInitializer<TDbContext>](kamisama-repositories-entityframeworkcore-initialization-defaultdatabaseinitializer-tdbcontext/index.md) | Class | Migration-only EF Core initializer. Migration runs when selected, while application-data and test-data stages complete without performing work. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs#L11) |
