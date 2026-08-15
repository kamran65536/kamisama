# KamiSama.Repositories.EntityFramework

[Back to KamiSama.Repositories.EntityFramework](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [DbRepository<TEntity, TDbContext>](kamisama-repositories-entityframework-dbrepository-tentity-tdbcontext/index.md) | Class | EF6 repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L145) |
| [DbRepository<TEntity>](kamisama-repositories-entityframework-dbrepository-tentity/index.md) | Class | EF6 repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L16) |
| [IOrderedQueryableExtensions](kamisama-repositories-entityframework-iorderedqueryableextensions/index.md) | Class | Pages ordered EF6 queries by synchronously counting all matches and asynchronously materializing one page. Cancellation does not cover the count, and count and data are separate queries. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/IOrderedQueryableExtensions.cs#L12) |
