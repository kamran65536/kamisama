# NotFoundException<TEntity>

<a id="notfoundexception-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/NotFoundException.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotFoundException.cs#L17)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Provides the `NotFoundException<TEntity>` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class NotFoundException<TEntity>(object? entityKey, string keyType = "key")
	: NotFoundException(typeof(TEntity).Name, entityKey, keyType)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotFoundException.cs#L17)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class NotFoundException<TEntity>(object? entityKey, string keyType = "key")
	: NotFoundException(typeof(TEntity).Name, entityKey, keyType)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entityKey` | `object?` | `-` | The `entityKey` value passed to this member. |
| `keyType` | `string` | `"key"` | The `keyType` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

