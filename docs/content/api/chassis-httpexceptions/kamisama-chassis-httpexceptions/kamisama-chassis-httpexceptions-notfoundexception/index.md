# NotFoundException

<a id="notfoundexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/NotFoundException.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotFoundException.cs#L7)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Provides the `NotFoundException` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class NotFoundException(string entityName, object? entityKey, string keyType = "key") : 
	HttpExceptionBase(nameof(NotFoundException), entityName, keyType, entityKey)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotFoundException.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class NotFoundException(string entityName, object? entityKey, string keyType = "key") : 
	HttpExceptionBase(nameof(NotFoundException), entityName, keyType, entityKey)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entityName` | `string` | `-` | The `entityName` value passed to this member. |
| `entityKey` | `object?` | `-` | The `entityKey` value passed to this member. |
| `keyType` | `string` | `"key"` | The `keyType` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-11.md) | Exposes the `StatusCode` value on `NotFoundException`. Read or set it as part of configuring or using the type. |

