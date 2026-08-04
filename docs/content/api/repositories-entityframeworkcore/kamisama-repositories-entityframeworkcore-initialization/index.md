# KamiSama.Repositories.EntityFrameworkCore.Initialization

[Back to KamiSama.Repositories.EntityFrameworkCore](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [DatabaseInitializerBase<TDbContext>](kamisama-repositories-entityframeworkcore-initialization-databaseinitializerbase-tdbcontext/index.md) | Class | Base EF Core database initializer with migration and seed hooks. Derive from it to centralize production seed data and optional test seed data for one DbContext. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L11) |
| [DefaultDatabaseInitializer<TDbContext>](kamisama-repositories-entityframeworkcore-initialization-defaultdatabaseinitializer-tdbcontext/index.md) | Class | Default Initializer, applies migration based on options. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs#L8) |
