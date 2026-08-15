# KamiSama.Repositories.Initialization

[Back to KamiSama.Repositories.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [DataInitializationOptions](kamisama-repositories-initialization-datainitializationoptions/index.md) | Class | Selects whether a database initializer should migrate, create required application data, or create test data. The `IDatabaseInitializer<TDbContext>` implementation defines the actual work and ordering. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/DataInitializationOptions.cs#L8) |
| [IDatabaseInitializer<TDbContext>](kamisama-repositories-initialization-idatabaseinitializer-tdbcontext/index.md) | Interface | Defines migration and seed-data initialization for one database context type. Implementations interpret `DataInitializationOptions` and own ordering, idempotency, persistence, and failure behavior. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/IDatabaseInitializer.cs#L10) |
