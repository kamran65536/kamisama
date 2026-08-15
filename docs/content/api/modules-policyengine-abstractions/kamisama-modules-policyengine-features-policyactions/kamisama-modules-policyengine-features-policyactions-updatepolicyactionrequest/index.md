# UpdatePolicyActionRequest

<a id="updatepolicyactionrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs:89](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs#L89)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyActions`

Kind: `Record`

## Description

Supplies replacement values for an existing policy-action definition. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UpdatePolicyActionRequest(
	string Name,
	string HandlerName,
	string ConfigurationSource,
	bool AllowsMultiple,
	bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs#L89)

Supplies replacement values for an existing policy-action definition. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdatePolicyActionRequest(
	string Name,
	string HandlerName,
	string ConfigurationSource,
	bool AllowsMultiple,
	bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The replacement name, which Core checks against other action names. |
| `HandlerName` | `string` | `-` | The replacement application-defined handler name. |
| `ConfigurationSource` | `string` | `-` | The replacement opaque handler configuration text. |
| `AllowsMultiple` | `bool` | `-` | Whether a future evaluator may retain multiple resolutions of the action. |
| `IsEnabled` | `bool` | `-` | Whether the updated definition is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

