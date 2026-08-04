# IDatabaseInitializer<TDbContext>

<a id="idatabaseinitializer-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/Initialization/IDatabaseInitializer.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/IDatabaseInitializer.cs#L10)

Namespace: `KamiSama.Repositories.Initialization`

Kind: `Interface`

## Description

Generic Data Initialization interface. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IDatabaseInitializer<TDbContext>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [InitializeAsync](method-initializeasync-18.md) | Initialize and migrates the database if necessary. Use it with the surrounding package APIs when composing application code. |

