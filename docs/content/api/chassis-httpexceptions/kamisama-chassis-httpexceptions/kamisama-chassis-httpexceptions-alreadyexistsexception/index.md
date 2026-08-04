# AlreadyExistsException

<a id="alreadyexistsexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/AlreadyExistsException.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/AlreadyExistsException.cs#L7)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

The entity already exists exception. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class AlreadyExistsException(string entityName, object entityKey, string keyType = "key") : 
	ConflictException(nameof(AlreadyExistsException), entityName, keyType, entityKey)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/AlreadyExistsException.cs#L7)

The entity already exists exception. Use it with the surrounding package APIs when composing application code.

```csharp
public class AlreadyExistsException(string entityName, object entityKey, string keyType = "key") : 
	ConflictException(nameof(AlreadyExistsException), entityName, keyType, entityKey)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entityName` | `string` | `-` | The `entityName` value passed to this member. |
| `entityKey` | `object` | `-` | The `entityKey` value passed to this member. |
| `keyType` | `string` | `"key"` | The `keyType` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

