# Dispose

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:128](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L128)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>`

Kind: `Method`

## Description

Releases no resources because the repository does not own the injected context. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual void Dispose();
```

## Parameters

This member does not declare parameters.

## Remarks

The context owner remains responsible for disposing the context.

## Example

```csharp
repository.Dispose(); // Does not dispose the injected DbContext.
```

