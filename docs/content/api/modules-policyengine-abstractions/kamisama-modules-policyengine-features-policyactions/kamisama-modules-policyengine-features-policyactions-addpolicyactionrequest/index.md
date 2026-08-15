# AddPolicyActionRequest

<a id="addpolicyactionrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs:74](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs#L74)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyActions`

Kind: `Record`

## Description

Supplies the values stored for a new reusable policy-action definition. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record AddPolicyActionRequest(
	string Name,
	string HandlerName,
	string ConfigurationSource,
	bool AllowsMultiple,
	bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs#L74)

Supplies the values stored for a new reusable policy-action definition. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddPolicyActionRequest(
	string Name,
	string HandlerName,
	string ConfigurationSource,
	bool AllowsMultiple,
	bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The action name, which Core checks for a case-insensitive duplicate. |
| `HandlerName` | `string` | `-` | The application-defined name of a handler; Core does not resolve or invoke it. |
| `ConfigurationSource` | `string` | `-` | The opaque configuration text stored for a future handler. |
| `AllowsMultiple` | `bool` | `-` | Whether a future evaluator may retain multiple resolutions of the action. |
| `IsEnabled` | `bool` | `-` | Whether the new definition is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

