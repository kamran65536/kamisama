# KamiSama.Repositories.Json

[Back to KamiSama.Repositories.Json](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [JsonRepository<TEntity>](kamisama-repositories-json-jsonrepository-tentity/index.md) | Class | Lazily reads an existing JSON array into a `HashSet<TEntity>` and rewrites the complete file after mutations. Writes are non-atomic, update only persists prior in-memory changes, failures are event-reported and suppressed, and locking does not coordinate live queries or other instances. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L23) |
