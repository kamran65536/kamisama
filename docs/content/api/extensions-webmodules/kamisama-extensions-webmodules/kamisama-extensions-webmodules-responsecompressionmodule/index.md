# ResponseCompressionModule

<a id="responsecompressionmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ResponseCompressionModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ResponseCompressionModule.cs#L7)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

Adds response compression module to app. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ResponseCompressionModule(Action<ResponseCompressionOptions>? configure) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ResponseCompressionModule.cs#L7)

Adds response compression module to app. Use it with the surrounding package APIs when composing application code.

```csharp
public class ResponseCompressionModule(Action<ResponseCompressionOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<ResponseCompressionOptions>?` | `-` | The `configure` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-22.md) | Runs the `ApplyConfigurationToAsync` operation on `ResponseCompressionModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureCompressionOptions](method-configurecompressionoptions-17.md) | configures the compression options, by default it calls configure parameter from the constructor. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-10.md) | Runs the `ConfigureServices` operation on `ResponseCompressionModule`. Use it when your code needs this specific behavior from the package. |

