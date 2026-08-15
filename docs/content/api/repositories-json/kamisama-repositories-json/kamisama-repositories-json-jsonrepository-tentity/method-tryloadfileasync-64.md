# TryLoadFileAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:64](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L64)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Loads an existing JSON array unless already cached, optionally discarding the cache first. Failures raise `LoadFailed` and return `false`.

## Declaration

```csharp
public async Task<bool> TryLoadFileAsync(bool forceReload, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `forceReload` | `bool` | `-` | Whether to discard the cached set and read the file again. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel file access or the semaphore wait. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | when entities are available; otherwise after raising `LoadFailed`. |

## Remarks

&lt;paramref name=&quot;forceReload&quot;/&gt; is applied before the per-instance semaphore is acquired and does not coordinate with other repository instances or processes.

## Example

```csharp
bool loaded = await repository.TryLoadFileAsync(forceReload: true, cancellationToken);
```

