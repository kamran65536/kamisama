# NotFoundException<TEntity>

<a id="notfoundexception-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/NotFoundException.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotFoundException.cs#L21)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents a request for an entity of type &lt;typeparamref name=&quot;TEntity&quot;/&gt; that could not be found. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class NotFoundException<TEntity>(object? entityKey, string keyType = "key")
	: NotFoundException(typeof(TEntity).Name, entityKey, keyType)
```

## Example

```csharp
using KamiSama.Chassis.HttpExceptions;

Product product = await repository.FindByIdAsync(id, cancellationToken)
    ?? throw new NotFoundException<Product>(id, nameof(id));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotFoundException.cs#L21)

Represents a request for an entity of type &lt;typeparamref name=&quot;TEntity&quot;/&gt; that could not be found. Use it with the surrounding package APIs when composing application code.

```csharp
public class NotFoundException<TEntity>(object? entityKey, string keyType = "key")
	: NotFoundException(typeof(TEntity).Name, entityKey, keyType)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entityKey` | `object?` | `-` | The key value that was not found. |
| `keyType` | `string` | `"key"` | The name of the key, such as `id` or `name`. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

