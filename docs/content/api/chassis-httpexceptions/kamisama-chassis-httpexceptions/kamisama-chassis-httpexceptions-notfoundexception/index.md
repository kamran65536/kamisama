# NotFoundException

<a id="notfoundexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/NotFoundException.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotFoundException.cs#L9)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents a request for an entity that could not be found. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class NotFoundException(string entityName, object? entityKey, string keyType = "key") : 
	HttpExceptionBase(nameof(NotFoundException), entityName, keyType, entityKey)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotFoundException.cs#L9)

Represents a request for an entity that could not be found. Use it with the surrounding package APIs when composing application code.

```csharp
public class NotFoundException(string entityName, object? entityKey, string keyType = "key") : 
	HttpExceptionBase(nameof(NotFoundException), entityName, keyType, entityKey)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entityName` | `string` | `-` | The entity type or display name included in localization arguments. |
| `entityKey` | `object?` | `-` | The key value that was not found. |
| `keyType` | `string` | `"key"` | The name of the key, such as `id` or `name`. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-13.md) | Gets HTTP status code 404. Use it with the surrounding package APIs when composing application code. |

