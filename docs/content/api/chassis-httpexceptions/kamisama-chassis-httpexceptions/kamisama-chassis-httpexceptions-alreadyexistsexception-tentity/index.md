# AlreadyExistsException<TEntity>

<a id="alreadyexistsexception-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/AlreadyExistsException.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/AlreadyExistsException.cs#L19)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents a conflict in which an entity of type &lt;typeparamref name=&quot;TEntity&quot;/&gt; already exists. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class AlreadyExistsException<TEntity>(object entityKey, string keyType = "key")
	: AlreadyExistsException(typeof(TEntity).Name, entityKey, keyType)
```

## Example

```csharp
using KamiSama.Chassis.HttpExceptions;

if (await repository.ExistsByNameAsync(request.Name, cancellationToken))
    throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/AlreadyExistsException.cs#L19)

Represents a conflict in which an entity of type &lt;typeparamref name=&quot;TEntity&quot;/&gt; already exists. Use it with the surrounding package APIs when composing application code.

```csharp
public class AlreadyExistsException<TEntity>(object entityKey, string keyType = "key")
	: AlreadyExistsException(typeof(TEntity).Name, entityKey, keyType)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entityKey` | `object` | `-` | The duplicate key value. |
| `keyType` | `string` | `"key"` | The name of the key, such as `id` or `name`. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

