# Dispose

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:103](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L103)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>`

Kind: `Method`

## Description

Dispose method, does nothing. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual void Dispose();
```

## Parameters

This member does not declare parameters.

## Example

```csharp
var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");
await repository.TryLoadFileAsync(forceReload: true, CancellationToken.None);

((System.IDisposable)repository).Dispose();
```

