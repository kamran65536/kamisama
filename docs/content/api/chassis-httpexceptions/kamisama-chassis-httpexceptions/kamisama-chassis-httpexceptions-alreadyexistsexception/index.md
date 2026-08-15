# AlreadyExistsException

<a id="alreadyexistsexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/AlreadyExistsException.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/AlreadyExistsException.cs#L9)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents a conflict in which an entity with the supplied key already exists. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class AlreadyExistsException(string entityName, object entityKey, string keyType = "key") : 
	ConflictException(nameof(AlreadyExistsException), entityName, keyType, entityKey)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/AlreadyExistsException.cs#L9)

Represents a conflict in which an entity with the supplied key already exists. Use it with the surrounding package APIs when composing application code.

```csharp
public class AlreadyExistsException(string entityName, object entityKey, string keyType = "key") : 
	ConflictException(nameof(AlreadyExistsException), entityName, keyType, entityKey)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entityName` | `string` | `-` | The entity type or display name included in localization arguments. |
| `entityKey` | `object` | `-` | The duplicate key value. |
| `keyType` | `string` | `"key"` | The name of the key, such as `id` or `name`. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

