# IOrderedQueryableExtensions

<a id="iorderedqueryableextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFramework/IOrderedQueryableExtensions.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/IOrderedQueryableExtensions.cs#L12)

Namespace: `KamiSama.Repositories.EntityFramework`

Kind: `Class`

## Description

Pages ordered EF6 queries by synchronously counting all matches and asynchronously materializing one page. Cancellation does not cover the count, and count and data are separate queries.

## Declaration

```csharp
public static class IOrderedQueryableExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [MakePagedAsync<T>](method-makepagedasync-t-26.md) | Counts the complete query and materializes the requested page. Use it with the surrounding package APIs when composing application code. |

