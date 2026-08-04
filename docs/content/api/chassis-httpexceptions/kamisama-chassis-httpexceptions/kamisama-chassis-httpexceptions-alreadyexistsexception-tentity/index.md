# AlreadyExistsException<TEntity>

<a id="alreadyexistsexception-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/AlreadyExistsException.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/AlreadyExistsException.cs#L15)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

The entity already exists exception. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class AlreadyExistsException<TEntity>(object entityKey, string keyType = "key")
	: AlreadyExistsException(typeof(TEntity).Name, entityKey, keyType)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/AlreadyExistsException.cs#L15)

The entity already exists exception. Use it with the surrounding package APIs when composing application code.

```csharp
public class AlreadyExistsException<TEntity>(object entityKey, string keyType = "key")
	: AlreadyExistsException(typeof(TEntity).Name, entityKey, keyType)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entityKey` | `object` | `-` | The `entityKey` value passed to this member. |
| `keyType` | `string` | `"key"` | The `keyType` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

