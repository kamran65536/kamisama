# Miscellaneous APIs Snapshot

- `KamiSama.Extensions.DependencyInjection`: annotate implementations with `AutoInjectScoped`, `AutoInjectSingleton`, or `AutoInjectTransient`, then scan with `AutoAddDependencies` or `AutoAddDependenciesFrom<T>`.
- `KamiSama.IranSystem.IranSystemEncoding`: custom `Encoding` implementation for Iran System text.
- `KamiSama.Extensions.NLog`: encrypted archive compression and Persian date layout renderers.
- `KamiSama.Testing.NSubstitute.TesterBuilderBase`: DI-first test builder with substitute registration and `BuildService<TService>()`.

Do not place passwords used by logging, tests, or external services in tracked source or configuration.
