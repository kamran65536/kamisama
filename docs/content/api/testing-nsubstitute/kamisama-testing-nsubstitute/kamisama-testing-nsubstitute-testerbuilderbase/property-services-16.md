# Services

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L16)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Property`

## Description

Gets the mutable service collection used for explicit registrations, generated substitutes, and target services. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public IServiceCollection Services { get; } = new ServiceCollection();
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `IServiceCollection` value. |

## Example

```csharp
builder.Services.AddSingleton<ISystemClock>(clock);
```

